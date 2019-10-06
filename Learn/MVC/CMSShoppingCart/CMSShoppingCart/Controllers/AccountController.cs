using CMSShoppingCart.Models.Data;
using CMSShoppingCart.Models.ViewModels.Account;
using CMSShoppingCart.Models.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CMSShoppingCart.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return RedirectToAction("~/account/login");
        }

        [HttpGet]
        [ActionName("create-account")]
        public ActionResult CreateAccount()
        {

            return View("CreateAccount");
        }

        [HttpPost]
        [ActionName("create-account")]
        public ActionResult CreateAccount(UserVM model)
        {
            if(!ModelState.IsValid)
            {
                return View("CreateAccount", model);
            }

            if(!(model.Password == model.PasswordConfirm))
            {
                ModelState.AddModelError("", "Passwords do not match");
                return View("CreateAccount", model);
            }

            using (DB db = new DB())
            {
                if(db.Users.Any(x => x.Username == model.Username))
                {
                    ModelState.AddModelError("", "Username already exists");
                    model.Username = "";
                    return View("CreateAccount", model);
                }

                UserDto dto = new UserDto(model);

                db.Users.Add(dto);
                db.SaveChanges();

                int id = dto.Id;

                UserRoleDto urdto = new UserRoleDto()
                {
                    UserId = id,
                    RoleId = 1
                };

                db.UserRoles.Add(urdto);
                db.SaveChanges();

            }
            TempData["SM"] = "Account registered. You may now log in.";
            return RedirectToAction("/login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            string username = User.Identity.Name;

            if(!string.IsNullOrEmpty(username))
            {
                return RedirectToAction("user-profile");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUserVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var isValid = false;

            using (DB db = new DB())
            {
                if(db.Users.Any(x => x.Username == model.Username && 
                    x.Password == model.Password))
                {
                    isValid = true;
                }

                if(!isValid)
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    return View(model);
                } else
                {
                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                    return Redirect(FormsAuthentication.GetRedirectUrl(model.Username,
                        model.RememberMe));
                }
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("/login");
        }

        [Authorize]
        public ActionResult UserNavPartial()
        {
            string username = User.Identity.Name;
            UserNavPartialVM model;

            using (DB db = new DB())
            {
                UserDto dto = db.Users.FirstOrDefault(x => x.Username == username);
                model = new UserNavPartialVM
                {
                    NameFirst = dto.NameFirst,
                    NameLast = dto.NameLast
                };
            }
            return PartialView(model);
        }

        [Authorize]
        [HttpGet, ActionName("user-profile")]
        public ActionResult UserProfile()
        {
            string username = User.Identity.Name;
            UserProfileVM model;
            using (DB db = new DB())
            {
                UserDto dto = db.Users.FirstOrDefault(x => x.Username == username);
                model = new UserProfileVM(dto);
            }

            return View("UserProfile", model);
        }

        [HttpPost, ActionName("user-profile")]
        public ActionResult UserProfile(UserProfileVM model)
        {
            const string vname = "UserProfile";

            if(!ModelState.IsValid)
            {
                return View(vname, model);
            }

            using (DB db = new DB())
            {
                if(!string.IsNullOrWhiteSpace(model.Password))
                {
                    if (!(model.Password == model.PasswordConfirm))
                    {
                        ModelState.AddModelError("", "Passwords do not match");
                        return View(vname, model);
                    }
                }

                string username = User.Identity.Name;

                if(db.Users.Where(x => x.Id != model.Id)
                    .Any(x => x.Username == username))
                {
                    ModelState.AddModelError("", "Username " + model.Username +
                        " already exists");
                    return View(vname, model);
                }

                UserDto dto = db.Users.Find(model.Id);
                UserDto.Map(dto, model, string.IsNullOrWhiteSpace(model.Password));
                db.SaveChanges();
            }

            TempData["SM"] = "Successfully edited user profile";
            return Redirect("~/account/user-profile");
        }

        [Authorize(Roles = "User")]
        public ActionResult Orders()
        {
            List<OrdersForUserVM> ordersForUser = new List<OrdersForUserVM>();
            using (DB db = new DB())
            {
                UserDto user = db.Users
                    .FirstOrDefault(x => x.Username == User.Identity.Name);
                List<OrderDto> orders = db.Orders.Where(x => x.UserId == user.Id).ToList();

                foreach(var order in orders)
                {
                    List<OrderDetailDto> dets = db.OrderDetails
                        .Where(x => x.OrderId == order.OrderId).ToList();
                    Dictionary<string, short> productAndQty = 
                        new Dictionary<string, short>();
                    decimal total = 0m;

                    foreach(var det in dets)
                    {
                        ProductDto prod = db.Products.FirstOrDefault(
                            x => x.Id == det.ProductId);
                        productAndQty.Add(prod.Name, det.Quantity);
                        total += det.Quantity * prod.Price;
                    }

                    ordersForUser.Add(new OrdersForUserVM
                    {
                        OrderNumber = order.OrderId,
                        ProductAndQty = productAndQty,
                        Total = total,
                        CreateOn = order.CreatedOn
                    });
                }
            }

            return View(ordersForUser);
        }
    }
}