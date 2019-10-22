using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Controllers.Models;

namespace Controllers.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AnotherAction()
        {
            return View();
        }

        public IActionResult AnotherView()
        {
            return View("SomeView");
        }
        
        public IActionResult ViewWithParameter()
        {
            string someString = "I am a string.";
            return View("ViewWithParameter", someString);
        }
                
        public IActionResult PassingData()
        {
            ViewBag.Fruit = "apples";
            ViewData["color"] = "red";
            TempData["number"] = 5;
            return View();
        }

        public IActionResult QueryString(string firstname,
            string lastname)
        {
            ViewBag.FirstName = firstname;
            ViewBag.LastName = lastname;

            return View();
        }

        public IActionResult Redirect()
        {
            return Redirect("https://www.google.com/");
        }
        
        public IActionResult RedirectToAction1()
        {
            return RedirectToAction("PassingData", "AnotherController", 
                new { id = 1 });
        }

        /*public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
