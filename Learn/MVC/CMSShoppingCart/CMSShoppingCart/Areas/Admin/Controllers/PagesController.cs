using CMSShoppingCart.Models.ViewModels.Pages;
using CMSShoppingCart.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSShoppingCart.Areas.Admin.Controllers
{
    public class PagesController : Controller
    {

        private const string SLUG_ERROR = "<slug_error>";

        // GET: Admin/Pages
        public ActionResult Index()
        {
            List<PageVM> pagesList;

            using (DB db = new DB())
            {
                pagesList = db.Pages
                    .ToArray()
                    .OrderBy(x => x.Sorting)
                    .Select(x => new PageVM(x))
                    .ToList();
            }

            return View(pagesList);
        }

        [HttpGet]
        public ActionResult AddPage()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddPage(PageVM model)
        {
            // Check model state
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            using (DB db = new DB())
            {
                PageDto dto = new PageDto();

                if(!CheckTitle(db, model.Id, model.Title))
                {
                    return View(model);
                }
                dto.Title = model.Title;
                dto.Slug = CheckSlug(db, 0, model.Title, model.Slug);

                if(dto.Slug == SLUG_ERROR)
                {
                    return View(model);
                }

                dto.Body = model.Body;
                dto.HasSidebar = model.HasSidebar;
                dto.Sorting = 100;

                db.Pages.Add(dto);
                db.SaveChanges();

            }

            // Set tempdata message
            TempData["SM"] = "You have added a new page.";

            return RedirectToAction("AddPage");
        }

        [HttpGet]
        public ActionResult EditPage(int Id)
        {
            PageVM model;

            using (DB db = new DB())
            {
                PageDto dto = db.Pages.Find(Id);

                if(dto == null)
                {
                    return Content("The page does not exist.");
                }

                model = new PageVM(dto);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult EditPage(PageVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            using (DB db = new DB())
            {
                int id = model.Id;
                PageDto dto = db.Pages.Find(id);

                if (!CheckTitle(db, model.Id, model.Title))
                {
                    return View(model);
                }
                dto.Title = model.Title;
                dto.Slug = CheckSlug(db, model.Id, model.Title, model.Slug);

                if(dto.Slug == SLUG_ERROR)
                {
                    return View(model);
                }

                dto.Body = model.Body;
                dto.Sorting = model.Sorting;
                dto.HasSidebar = model.HasSidebar;

                db.SaveChanges();
            }
            TempData["SM"] = "Successfully edited the page.";

            return RedirectToAction("EditPage");
        }

        [HttpGet]
        public ActionResult PageDetails(int id)
        {
            PageVM model;

            using (DB db = new DB())
            {
                PageDto dto = db.Pages.Find(id);

                if(dto == null)
                {
                    return Content("The page does not exist.");
                }

                model = new PageVM(dto);

                return View(model);
            }
        }

        public ActionResult DeletePage(int id)
        {
            using (DB db = new DB())
            {
                PageDto dto = db.Pages.Find(id);
                db.Pages.Remove(dto);
                db.SaveChanges();
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        public void ReorderPages(int[] id)
        {
            using (DB db = new DB())
            {
                int count = 1;
                PageDto dto;
                foreach(var pageId in id)
                {
                    dto = db.Pages.Find(pageId);
                    dto.Sorting = count;
                    db.SaveChanges();
                    count += 1;
                }
            }
        }

        [HttpGet]
        public ActionResult EditSidebar()
        {
            SidebarVM model;

            using (DB db = new DB())
            {
                SidebarDto dto = db.Sidebars.Find(1);

                model = new SidebarVM(dto);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult EditSidebar(SidebarVM model)
        {
            using (DB db = new DB())
            {
                SidebarDto dto = db.Sidebars.Find(1);

                dto.Body = model.Body;

                db.SaveChanges();
            }

            TempData["SM"] = "Sidebar successfully edited.";

            return RedirectToAction("EditSidebar");
        }

        private bool CheckTitle(DB db, int id, string title)
        {
            var unique = db.Pages.Where(p => p.Id != id);
            if (unique.Any(p => p.Title == title))
            {
                ModelState.AddModelError("", "Title already exists.");
                return false;
            }
            return true;
        }

        private string CheckSlug(DB db, int id, string title, string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
            {
                slug = title.Replace(" ", "-").ToLower();
            }
            else
            {
                slug = slug.Replace(" ", "-").ToLower();
            }

            var unique = db.Pages.Where(p => p.Id != id);
            if (unique.Any(p => p.Slug == slug))
            {
                ModelState.AddModelError("", "Slug already exists.");
                slug = SLUG_ERROR;
            }

            return slug;
        }
    }
}