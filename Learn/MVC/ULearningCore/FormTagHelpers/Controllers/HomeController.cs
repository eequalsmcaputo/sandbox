using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormTagHelpers.Models;

namespace FormTagHelpers.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View(repository.Fruits);
        }

        public IActionResult AddFruit()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFruit(Fruit fruit)
        {
            repository.AddFruit(fruit);
            return RedirectToAction("Index");
        }

        public IActionResult EditFruit()
        {
            return View("AddFruit", repository.Fruits.FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditFruit(Fruit fruit)
        {
            var edit = repository.Fruits.FirstOrDefault(f => f.Name == fruit.Name);
            edit.Price = fruit.Price;
            edit.Qty = fruit.Qty;
            
            return RedirectToAction("Index");
        }
    }
}
