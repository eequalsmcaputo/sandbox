using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMSShoppingCart.Models.ViewModels.Shop;
using CMSShoppingCart.Models.ViewModels.Pages;
using CMSShoppingCart.Models.Data;

namespace CMSShoppingCart.Controllers
{
    public class ShopController : UtilityController
    {
        // GET: Shop
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Pages");
        }

        public ActionResult CategoryMenuPartial()
        {
            List<CategoryVM> catList;

            using (DB db = new DB())
            {
                catList = db.Categories.ToArray().OrderBy(x => x.Sorting)
                    .Select(x => new CategoryVM(x)).ToList();
            }

            return View(catList);
        }

        public ActionResult Category(string name)
        {
            List<ProductVM> prodList;

            using (DB db = new DB())
            {
                CategoryDto catDto = db.Categories.Where(x => x.Slug == name)
                    .FirstOrDefault();
                int catId = catDto.Id;

                prodList = db.Products.ToArray()
                    .Where(x => x.CategoryId == catId)
                    .Select(x => new ProductVM(x))
                    .ToList();

                var prodCat = db.Products.Where(x => x.CategoryId == catId)
                    .FirstOrDefault();

                ViewBag.CategoryName = prodCat.Category.Name;
            }

            return View(prodList);
        }

        [ActionName("product-details")]
        public ActionResult ProductDetails(string name)
        {
            ProductDto dto;
            ProductVM model;
            int id = 0;
            using (DB db = new DB())
            {

                if(!db.Products.Any(x => x.Slug == name))
                {
                    return RedirectToAction("Index", "Shop");
                }

                dto = db.Products.Where(x => x.Slug == name).FirstOrDefault();

                id = dto.Id;
                model = new ProductVM(dto);

            }

            model.GalleryImages = GetGalleryImages(id);

            return View("ProductDetails", model);
        }
    }
}