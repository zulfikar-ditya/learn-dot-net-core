using BulkyWebRazor__Temp.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor__Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {

        private ApplicationDbContext _db;

        public List<Category> CategoryList { get; set; }


        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
