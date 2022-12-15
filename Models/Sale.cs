using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cars.Data;

namespace Cars.Models;

public class Sale
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public float Distance { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [Required]
    public CarsCategories Categories { get; set; }
    public int capacity { get; set; } = 12;

    // car
    [Required]
    public int CarId { get; set; }
    public Car car { get; set; }
}