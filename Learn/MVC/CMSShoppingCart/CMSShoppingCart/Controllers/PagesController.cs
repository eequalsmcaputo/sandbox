using CMSShoppingCart.Models.Data;
using CMSShoppingCart.Models.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSShoppingCart.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        [HttpGet]
        public ActionResult Index(string page = "")
        {
            if(page == "")
            {
                page = "home";
            }

            PageVM model;
            PageDto dto;

            using (DB db = new DB())
            {
                if(! db.Pages.Any(x => x.Slug == page)) {
                    return RedirectToAction("Index", new { page = "" });
                }

                dto = db.Pages.Where(x => x.Slug == page).FirstOrDefault();

                ViewBag.PageTitle = dto.Title;
                if (dto.HasSidebar == true)
                {
                    ViewBag.Sidebar = "Yes";
                } else
                {
                    ViewBag.Sidebar = "No";
                }

                model = new PageVM(dto);

            }

                return View(model);
        }

        public ActionResult PagesMenuPartial()
        {
            List<PageVM> pages;

            using (DB db = new DB())
            {
                pages = db.Pages.ToArray()
                    .OrderBy(x => x.Sorting)
                    .Where(x => x.Slug != "home")
                    .Select(x => new PageVM(x))
                    .ToList();
            }
            return PartialView(pages);
        }

        public ActionResult SidebarPartial()
        {
            SidebarVM model;

            using (DB db = new DB())
            {
                SidebarDto dto = db.Sidebars.Find(1);
                model = new SidebarVM(dto);
            }

            return PartialView(model);
        }
    }
}