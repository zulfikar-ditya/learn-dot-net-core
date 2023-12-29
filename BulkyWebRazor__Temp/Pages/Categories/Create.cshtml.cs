using BulkyWebRazor__Temp.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyWebRazor__Temp.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _db;

        public Category Category{ get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
