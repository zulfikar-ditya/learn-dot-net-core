using BulkyApp.DataAccess.Repository.Interfaces;
using BulkyApp.Models.Models;
using BulkyApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ProductRepositoryInterface productRepository;

        private readonly CategoryRepositoryInterface categoryRepository;

        public ProductController(ProductRepositoryInterface _productRepository, CategoryRepositoryInterface _categoryRepository)
        {
            productRepository = _productRepository;
            categoryRepository = _categoryRepository;
        }

        public IActionResult Index()
        {
            List<Product> products = productRepository.GetAll().ToList();

            return View(products);
        }

        public IActionResult Create() 
        {
            // IEnumerable<SelectListItem> CategorySelect = categoryRepository.GetAll().Select(c => new SelectListItem
            // {
            //     Text = c.Name,
            //     Value = c.Id.ToString()
            // });

            // ViewBag.CategorySelect = CategorySelect;

            ProductViewModel productViewModel = new ProductViewModel
            {
                Product = new Product(),
                CategoryList = categoryRepository.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid == false)
            {
                TempData["Error"] = "Error creating product";
                return View(product);
            }

            productRepository.Create(product.Product);
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

            ProductViewModel productViewModel = new ProductViewModel
            {
                Product = product,
                CategoryList = categoryRepository.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };

            return View();
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            if (ModelState.IsValid == false)
            {
                TempData["Error"] = "Error updating product";
                return View(product);
            }

            productRepository.Update(product.Product);
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