using BulkyApp.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyApp.Models.ViewModel
{
    public class ProductViewModel 
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}