using BulkyWebRazor__Temp.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BulkyWebRazor__Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {

        private ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _context.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            Category? obj = _context.Categories.Find(Category.Id);

            if (obj == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(obj);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
