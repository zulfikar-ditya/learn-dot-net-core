using BulkyWebRazor__Temp.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor__Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private ApplicationDbContext _context;

        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _context = db;
        }

        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _context.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(Category);
                _context.SaveChanges();

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
