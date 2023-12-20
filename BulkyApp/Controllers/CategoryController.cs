using BulkyApp.Data;
using BulkyApp.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
