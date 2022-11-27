using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cars.Data;

namespace Cars.Models;

public class Sale
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public float Distance { get; set; }
    public string ImageUrl { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public CarsCategories Categories { get; set; }

    // car
    public int CarId { get; set; }
    [ForeignKey("CarId")]
    public Car car { get; set; }
}