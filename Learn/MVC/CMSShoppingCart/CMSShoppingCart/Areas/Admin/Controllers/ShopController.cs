using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Helpers;
using CMSShoppingCart.Models.Data;
using CMSShoppingCart.Models.ViewModels.Shop;
using PagedList;
using CMSShoppingCart.Areas.Admin.Models.ViewModels.Shop;

namespace CMSShoppingCart.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ShopController : UtilityController
    {
        // GET: Admin/Shop
        [HttpGet]
        public ActionResult Categories()
        {
            List<CategoryVM> list;

            using (DB db = new DB())
            {
                list = db.Categories
                    .ToList()
                    .OrderBy(x => x.Sorting)
                    .Select(x => new CategoryVM(x))
                    .ToList();
            }
                return View(list);
        }

        [HttpPost]
        public string AddNewCategory(string catName)
        {
            string id;

            using (DB db = new DB())
            {
                if(db.Categories.Any(x => x.Name == catName))
                {
                    return "titletaken";
                }

                CategoryDto dto = new CategoryDto()
                {
                    Name = catName,
                    Slug = catName.Replace(" ", "-").ToLower(),
                    Sorting = 100
                };

                db.Categories.Add(dto);
                db.SaveChanges();

                id = dto.Id.ToString();
            }

            return id;

        }

        [HttpPost]
        public void ReorderCategories(int[] ids)
        {
            using (DB db = new DB())
            {
                int count = 1;
                CategoryDto dto;
                foreach (var categoryId in ids)
                {
                    dto = db.Categories.Find(categoryId);
                    dto.Sorting = count;
                    db.SaveChanges();
                    count += 1;
                }
            }
        }

        
        public string DeleteCategory(int id)
        {
            using (DB db = new DB())
            {
                var cat = db.Categories.Find(id);

                if(cat == null)
                {
                    return "Category not found.";
                }

                db.Categories.Remove(cat);
                db.SaveChanges();
            }

            return "Category deleted.";
        }

        [HttpPost]
        public string RenameCategory(string newCatName, int id)
        {
            using (DB db = new DB())
            {
                if (db.Categories.Any(x => x.Name == newCatName))
                {
                    return "titletaken";
                }

                CategoryDto dto = db.Categories.Find(id);
                dto.Name = newCatName;
                dto.Slug = newCatName.Replace(" ", "-").ToLower();

                db.SaveChanges();
            }

            return "OK";
        }

        public ActionResult AddProduct()
        {
            ProductVM model = new ProductVM();
            using (DB db = new DB())
            {
                model.Categories = new SelectList(
                    db.Categories.ToList(), "Id", "Name");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddProduct(ProductVM model,
            HttpPostedFileBase file)
        {
            int productId;

            using (DB db = new DB())
            {
                if (!ModelState.IsValid)
                {
                    model.Categories = new SelectList(
                        db.Categories.ToList(), "Id", "Name");
                    return View(model);
                }

                if (db.Products.Any(p => p.Name == model.Name))
                {
                    model.Categories = new SelectList(
                        db.Categories.ToList(), "Id", "Name");
                    ModelState.AddModelError("",
                        "That product name is taken.");
                    return View(model);
                }

                var product = new ProductDto();
                product.Name = model.Name;
                product.Slug = model.Name.Replace(" ", "-").ToLower();
                product.Description = model.Description;
                product.Price = model.Price;
                product.CategoryId = model.CategoryId;

                db.Products.Add(product);
                db.SaveChanges();

                productId = product.Id;

                TempData["SM"] = "Product added";

                #region upload image

                // Create necessary directories
                var origDir = GetOrigDir();

                var basePath = GetBasePath(origDir, productId);
                var thumbs1 = Path.Combine(basePath, "Thumbs");
                var gallery = Path.Combine(basePath, "Gallery");
                var thumbs2 = Path.Combine(gallery, "Thumbs");

                CreateDirIfNotExists(thumbs1);
                CreateDirIfNotExists(gallery);
                CreateDirIfNotExists(thumbs2);

                // Check if a file was uploaded
                if (file != null && file.ContentLength > 0)
                {
                    // Verify file extension
                    if (!HasValidFileExtension(file))
                    {
                        model.Categories = new SelectList(
                            db.Categories.ToList(), "Id", "Name");
                        ModelState.AddModelError("", "Invalid file extension.");
                        return View(model);
                    }

                    // Save image name to DTO
                    product.ImageName = file.FileName;
                    db.SaveChanges();

                    UploadFiles(file, basePath, thumbs1);
                }

                #endregion

            }

            return RedirectToAction("AddProduct");
        }

        public ActionResult Products(int? page, int? catId)
        {
            List<ProductVM> productVMs;
            var pageNumber = page ?? 1;

            using (DB db = new DB())
            {
                productVMs = db.Products.ToArray()
                    .Where(x => catId == null || catId == 0 || 
                        x.CategoryId == catId)
                    .Select(x => new ProductVM(x))
                    .ToList();

                ViewBag.Categories = new SelectList(db.Categories.ToList(),
                    "Id", "Name");
                ViewBag.SelectedCat = catId.ToString();

                var onePageOfProducts = productVMs.ToPagedList(
                    pageNumber, 3);

                ViewBag.OnePageOfProducts = onePageOfProducts;
            }

            return View(productVMs);
        }

        public ActionResult EditProduct(int id)
        {
            ProductVM model;

            using (DB db = new DB())
            {
                ProductDto dto = db.Products.Find(id);

                if(dto == null)
                {
                    return Content("Product does not exist.");
                }

                model = new ProductVM(dto);

                model.Categories = new SelectList(
                    db.Categories.ToList(), "Id", "Name");

                model.GalleryImages = GetGalleryImages(id);
                
            }
            
            return View(model);
        }

        [HttpPost]
        public ActionResult EditProduct(ProductVM model, 
            HttpPostedFileBase file)
        {
            int id = model.Id;

            using (DB db = new DB())
            {
                model.Categories = new SelectList(
                    db.Categories.ToList(), "Id", "Name");

                model.GalleryImages = GetGalleryImages(id);

                if(!ModelState.IsValid)
                {
                    return View(model);
                }

                if (db.Products.Where(p => p.Id != id)
                    .Any(p => p.Name == model.Name))
                {
                    ModelState.AddModelError("", 
                        "That product name is taken.");
                    return View(model);
                }

                ProductDto dto = db.Products.Find(id);

                dto.Name = model.Name;
                dto.Slug = model.Name.Replace(" ", "-").ToLower();
                dto.Description = model.Description;
                dto.Price = model.Price;
                dto.CategoryId = model.CategoryId;
                dto.ImageName = model.ImageName;

                #region image upload

                if(file != null && file.ContentLength > 0)
                {
                    if(!HasValidFileExtension(file))
                    {
                        ModelState.AddModelError("", "Invalid file extension.");
                        return View(model);
                    }

                    var origDir = GetOrigDir();
                    var basePath = GetBasePath(origDir, id);
                    var thumbs = Path.Combine(basePath, id.ToString() + "\\Thumbs");

                    DirectoryInfo di1 = new DirectoryInfo(basePath);
                    DirectoryInfo di2 = new DirectoryInfo(thumbs);

                    foreach(FileInfo f in di1.GetFiles())
                    {
                        f.Delete();
                    }

                    foreach(FileInfo f in di2.GetFiles())
                    {
                        f.Delete();
                    }

                    dto.ImageName = file.FileName;
                    db.SaveChanges();

                    UploadFiles(file, basePath, thumbs);
                }

                #endregion

                TempData["SM"] = "Product edited.";
            }

            return RedirectToAction("EditProduct");
        }

        public ActionResult DeleteProduct(int id)
        {
            using (DB db = new DB())
            {
                ProductDto dto = db.Products.Find(id);
                db.Products.Remove(dto);
                db.SaveChanges();
            }

            var origDir = GetOrigDir();
            string pathString = Path.Combine(origDir.ToString(),
                "Products\\" + id.ToString());

            if(Directory.Exists(pathString))
            {
                Directory.Delete(pathString, true);
            }

            return RedirectToAction("Products");
        }

        [HttpPost]
        public void SaveGalleryImages(int id)
        {
            foreach(string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];

                if(file != null && file.ContentLength > 0)
                {
                    var origDir = GetOrigDir();
                    string basePath = GetBasePath(origDir, id);
                    string gallery = Path.Combine(basePath, "\\Gallery");
                    string thumbs = Path.Combine(gallery, "\\Thumbs");

                    var path = gallery + "\\" + file.FileName;
                    var path2 = thumbs + "\\" + file.FileName;
                    file.SaveAs(path);
                    WebImage img = new WebImage(file.InputStream);
                    img.Resize(200, 200);
                    img.Save(path2);
                }
            }
        }

        public ActionResult Orders()
        {
            List<OrdersForAdminVM> ordersForAdmin = new List<OrdersForAdminVM>();
            using (DB db = new DB())
            {
                List<OrderDto> orders = db.Orders.ToList();
                    //.Select(x => new OrderVM(x)).ToList();
                foreach(var order in orders)
                {
                    Dictionary<string, short> productAndQty =
                        new Dictionary<string, short>();

                    decimal total = 0m;

                    List<OrderDetailDto> orderDetList = db.OrderDetails
                        .Where(x => x.OrderId == order.OrderId).ToList();

                    string username = order.User.Username;

                    foreach(var det in orderDetList)
                    {
                        var prod = db.Products.FirstOrDefault(p => p.Id == det.ProductId);
                        productAndQty.Add(prod.Name, det.Quantity);
                        total += prod.Price * det.Quantity;
                    }

                    ordersForAdmin.Add(new OrdersForAdminVM
                    {
                        OrderNumber = order.OrderId,
                        Username = username,
                        ProductAndQty = productAndQty,
                        Total = total,
                        CreateOn = order.CreatedOn
                    });
                }
            }
            return View(ordersForAdmin);
        }

        #region utilities

        private void UploadFiles(HttpPostedFileBase file, string pathString1,
            string pathString2)
        {
            // Set original and thumb image path
            var path = string.Format("{0}\\{1}", pathString1, file.FileName);
            var path2 = string.Format("{0}\\{1}", pathString2, file.FileName);

            // Save original
            file.SaveAs(path);

            // Create and save thumbs
            WebImage img = new WebImage(file.InputStream);
            img.Resize(200, 200);
            img.Save(path2);
        }

        private DirectoryInfo GetOrigDir()
        {
            return new DirectoryInfo(
                    string.Format("{0}Images\\Upload",
                    Server.MapPath(@"\")));
        }

        private string GetBasePath(DirectoryInfo origDir, int id)
        {
            return Path.Combine(origDir.ToString(), "Products\\" + id.ToString());
        }

        private void CreateDirIfNotExists(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        private bool HasValidFileExtension(HttpPostedFileBase file)
        {
            string ext = file.ContentType.ToLower();
            return !(ext != "image/jpg" &&
                ext != "image/jpeg" &&
                ext != "image/pjpeg" &&
                ext != "image/gif" &&
                ext != "image/x-png" &&
                ext != "image/png");
        }

        #endregion

    }
}