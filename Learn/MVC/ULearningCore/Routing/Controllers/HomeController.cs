using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Routing.Models;

namespace Routing.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Controller = "HomeController";
            ViewBag.Action = "Index";
            return View("Result");
        }

        public IActionResult Blog()
        {
            ViewBag.Controller = "HomeController";
            ViewBag.Action = "Blog";
            return View("Result");
        }
        
        public IActionResult ThirdSegment(string id)
        {
            ViewBag.Controller = "HomeController";
            ViewBag.Action = "ThirdSegment";

            // Method 1 of retrieving parameters
            //ViewBag.Id = RouteData.Values["id"];

            // Method 2
            ViewBag.Id = id;

            return View("Result");
        }
               
        public IActionResult All(string id)
        {
            ViewBag.Controller = "HomeController";
            ViewBag.Action = "All";

            ViewBag.Id = id;
            ViewBag.All = RouteData.Values["all"];

            return View("Result");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
