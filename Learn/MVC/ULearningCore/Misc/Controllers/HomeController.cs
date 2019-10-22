using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Misc.Models;

namespace Misc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

        public JsonResult JsonData()
        {
            Fruit[] fruits = new Fruit[]
            {
                new Fruit {Id = 1, Name = "Bananas", Price = 1.50m },
                new Fruit {Id = 2, Name = "Apples", Price = 1.30m },
                new Fruit {Id = 3, Name = "Oranges", Price = 1.10m }
            };

            return Json(fruits);
        }
    }
}
