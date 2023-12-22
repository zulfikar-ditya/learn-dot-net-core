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
                TempData["Error"] = "Error creating category";
                return View(category);
            }

            _DB.Categories.Add(category);
            _DB.SaveChanges();

            TempData["Success"] = "Category created successfully";  

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
                TempData["Error"] = "Error updating category";
                return View(category);
            }

            _DB.Categories.Update(category);
            _DB.SaveChanges();

            TempData["Success"] = "Category updated successfully";

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

            TempData["Success"] = "Category deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
