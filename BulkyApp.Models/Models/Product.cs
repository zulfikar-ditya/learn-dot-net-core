using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyApp.Models.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    public string? Description { get; set; }

    [Required]
    public string ISBN { get; set; }

    [Required]
    public string Author { get; set; }

    [Required]
    [DisplayName("List Price")]
    [Range(0, 10000)]
    public double ListPrice { get; set; }

    [Required]
    [DisplayName("Price for 1-50")]
    [Range(0, 10000)]
    public double Price { get; set; }

    [Required]
    [DisplayName("Price for 50+")]
    [Range(0, 10000)]
    public double Price50 { get; set; }

    [Required]
    [DisplayName("Price for 100+")]
    [Range(0, 10000)]
    public double Price100 { get; set; }

    [Required]
    [DisplayName("Category")]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

    public string? ImageUrl { get; set; }
}