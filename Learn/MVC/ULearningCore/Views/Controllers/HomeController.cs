using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Views.Models;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Fruit fruit = new Fruit
            {
                Name = "Bananas"
            };
            return View(fruit);
        }
        public IActionResult Section()
        {
            return View();
        }
    }
}
