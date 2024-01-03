using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyApp.Models.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Title { get; set; }

    public string? Description { get; set; }

    [Required]
    public required string ISBN { get; set; }

    [Required]
    public required string Author { get; set; }

    [Required]
    [DisplayName("List Price")]
    [Range(0, 10000)]
    public required double ListPrice { get; set; }

    [Required]
    [DisplayName("Price for 1-50")]
    [Range(0, 10000)]
    public required double Price { get; set; }

    [Required]
    [DisplayName("Price for 50+")]
    [Range(0, 10000)]
    public required double Price50 { get; set; }

    [Required]
    [DisplayName("Price for 100+")]
    [Range(0, 10000)]
    public required double Price100 { get; set; }
}