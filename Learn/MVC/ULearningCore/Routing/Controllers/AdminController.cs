using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers
{
    [Route("test/{controller}/{action}")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Controller = "AdminController";
            ViewBag.Action = "Index";
            return View("Result");
        }

        //[Route("someRoute")]
        public IActionResult Pages()
        {
            ViewBag.Controller = "AdminController";
            ViewBag.Action = "Pages";

            return View("Result");
        }

        //[Route("{controller}/someNews")]
        public IActionResult News()
        {
            ViewBag.Controller = "AdminController";
            ViewBag.Action = "News";

            return View("Result");
        }
    }
}