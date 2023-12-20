using System.ComponentModel.DataAnnotations;

namespace BulkyApp.Models;

public class Category
{
    [Key] // defining the primary keys
    public int Id { get; set; }
    [Required] // determine the column is required

    public string Name { get; set; }

    public int DisplayOrder { get; set; }
}