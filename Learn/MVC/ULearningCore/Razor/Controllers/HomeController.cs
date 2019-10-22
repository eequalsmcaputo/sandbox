using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Product model = new Product()
            {
                Id = 1,
                Name = "Bananas",
                Description = "Nice bananas",
                Price = 1.50m
            };

            ViewBag.Qty = 4;

            return View(model);
        }

        public IActionResult Collections()
        {
            Product[] products =
            {
                new Product { Name = "Bananas", Price = 1.40m },
                new Product { Name = "Apples", Price = 1.70m },
                new Product { Name = "Oranges", Price = 1.80m },
                new Product { Name = "Kiwis", Price = 1.90m }
            };

            return View(products);
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
