using System.Runtime.CompilerServices;
using BulkyApp.Data;
using BulkyApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _DB;

        public CategoryController(ApplicationDbContext db) {
            _DB = db;
        }

        public IActionResult Index()
        {
            List<Category> categories = _DB.Categories.ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid == false) {
                return View(category);
            }

            _DB.Categories.Add(category);
            _DB.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null) {
                return NotFound();
            }

            Category? category = _DB.Categories.Find(id);
            if (category == null) {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid == false) {
                return View(category);
            }

            _DB.Categories.Update(category);
            _DB.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null) {
                return NotFound();
            }

            Category? category = _DB.Categories.Find(id);
            if (category == null) {
                return NotFound();
            }

            _DB.Categories.Remove(category);
            _DB.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
