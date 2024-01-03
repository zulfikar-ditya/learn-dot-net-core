using BulkyApp.DataAccess.Repository.Interfaces;
using BulkyApp.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ProductRepositoryInterface productRepository;

        public ProductController(ProductRepositoryInterface _productRepository)
        {
            productRepository = _productRepository;
        }

        public IActionResult Index()
        {
            List<Product> products = productRepository.GetAll().ToList();

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid == false)
            {
                TempData["Error"] = "Error creating product";
                return View(product);
            }

            productRepository.Create(product);
            productRepository.Save();

            TempData["Success"] = "Product created successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            Product? product = productRepository.Get(u => u.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid == false)
            {
                TempData["Error"] = "Error updating product";
                return View(product);
            }

            productRepository.Update(product);
            productRepository.Save();

            TempData["Success"] = "Product updated successfully";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            Product? product = productRepository.Get(u => u.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            productRepository.Delete(product);
            productRepository.Save();

            TempData["Success"] = "Product deleted successfully";

            return RedirectToAction("Index");
        }
    }
}