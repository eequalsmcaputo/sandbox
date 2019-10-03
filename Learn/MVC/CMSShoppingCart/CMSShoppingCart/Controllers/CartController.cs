using CMSShoppingCart.Models.Data;
using CMSShoppingCart.Models.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSShoppingCart.Controllers
{
    public class CartController : UtilityController
    {
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session["cart"] as List<CartVM> ?? new List<CartVM>();
            if(cart.Count == 0)
            {
                ViewBag.Message = "Your cart is empty.";
                return View();
            }
            decimal Total = 0m;

            foreach (var item in cart)
            {
                Total += item.Total;
            }

            ViewBag.GrandTotal = Total;

            return View(cart);
        }

        public ActionResult CartPartial()
        {
            CartVM model = new CartVM();
            int qty = 0;
            decimal price = 0m;

            if (Session["cart"] != null)
            {
                var list = (List<CartVM>)Session["cart"];

                foreach(var item in list)
                {
                    qty += item.Quantity;
                    price += item.Total;
                }

                model.Quantity = qty;
                model.Price = price;
            } else
            {
                model.Quantity = 0;
                model.Price = 0m;
            }

            return PartialView(model);
        }

        public ActionResult AddToCartPartial(int id)
        {
            List<CartVM> cart = Session["cart"] as List<CartVM> ?? new List<CartVM>();
            CartVM model = new CartVM();

            using(DB db = new DB())
            {
                ProductDto product = db.Products.Find(id);
                var productInCart = cart.FirstOrDefault(x => x.ProductId == id);

                if(productInCart == null)
                {
                    cart.Add(new CartVM
                    {
                        ProductId = product.Id,
                        PrdouctName = product.Name,
                        Quantity = 1,
                        Price = product.Price,
                        Image = product.ImageName
                    });
                } else
                {
                    productInCart.Quantity++;
                }

                int qty = 0;
                decimal price = 0m;

                foreach(var item in cart)
                {
                    qty += item.Quantity;
                    price += item.Quantity * item.Price;
                }

                model.Quantity = qty;
                model.Price = price;

                Session["cart"] = cart;
            }

            return PartialView(model);
        }

        public JsonResult IncrementProduct(int productId)
        {
            return ChangeProductQty(productId, QtyOps.Increment);
        }

        public JsonResult DecrementProduct(int productId)
        {
            return ChangeProductQty(productId, QtyOps.Decrement);
        }

        private JsonResult ChangeProductQty(int productId, QtyOps op)
        {
            List<CartVM> cart = Session["cart"] as List<CartVM> ?? new List<CartVM>();
            using (DB db = new DB())
            {
                CartVM model = cart.FirstOrDefault(x => x.ProductId == productId);
                QtyOp(ref model, op);
                if(op == QtyOps.Decrement && model.Quantity == 0)
                {
                    cart.Remove(model);
                }
                var result = new { qty = model.Quantity, price = model.Price };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public void RemoveProduct(int productId)
        {
            List<CartVM> cart = Session["cart"] as List<CartVM> ?? new List<CartVM>();

            CartVM model = cart.FirstOrDefault(x => x.ProductId == productId);
            cart.Remove(model);
        }

        private enum QtyOps : byte
        {
            Increment,
            Decrement
        }

        private void QtyOp(ref CartVM model, QtyOps op)
        {
            switch(op)
            {
                case QtyOps.Increment:
                    model.Quantity++;
                    break;
                case QtyOps.Decrement:
                    model.Quantity--;
                    break;
                default:
                    break;
            }
        }
    }

}