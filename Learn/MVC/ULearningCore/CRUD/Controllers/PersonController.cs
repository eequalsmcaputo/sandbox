using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class PersonController : Controller
    {
        private readonly CrudContext _context;

        public PersonController(CrudContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.People.ToList());
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Person person = _context.People.SingleOrDefault(x => x.Id == id);
            if( person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person person = _context.People.SingleOrDefault(x => x.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Person person)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","There were errors.");
                return View(person);
            }
            _context.Update(person);
            _context.SaveChanges();

            TempData["message"] = "Person edited";

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "There were errors.");
                return View(person);
            }

            _context.Add(person);
            _context.SaveChanges();

            TempData["message"] = "Person added";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person person = _context.People.SingleOrDefault(x => x.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Remove(person);
            _context.SaveChanges();

            TempData["message"] = "Person deleted";

            return RedirectToAction("Index");
        }
    }
}