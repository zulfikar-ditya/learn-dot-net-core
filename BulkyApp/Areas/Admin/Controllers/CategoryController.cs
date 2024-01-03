using System.Runtime.CompilerServices;
using BulkyApp.DataAccess.Data;
using BulkyApp.DataAccess.Repository.Interfaces;
using BulkyApp.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly CategoryRepositoryInterface categoryRepository;

        public CategoryController(CategoryRepositoryInterface _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public IActionResult Index()
        {
            List<Category> categories = categoryRepository.GetAll().ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid == false)
            {
                TempData["Error"] = "Error creating category";
                return View(category);
            }

            categoryRepository.Create(category);
            categoryRepository.Save();

            TempData["Success"] = "Category created successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            Category? category = categoryRepository.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid == false)
            {
                TempData["Error"] = "Error updating category";
                return View(category);
            }

            categoryRepository.Update(category);
            categoryRepository.Save();

            TempData["Success"] = "Category updated successfully";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            Category? category = categoryRepository.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            categoryRepository.Delete(category);
            categoryRepository.Save();

            TempData["Success"] = "Category deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
