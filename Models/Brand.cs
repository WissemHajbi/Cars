using System.ComponentModel.DataAnnotations;

namespace Cars.Models;

public class Brand
{
    [Key]
    public int Id { get; set; }
    public string PictureUrl { get; set; }
    public string Name { get; set; }
    public string Origin { get; set; }
    public List<Car> Cars { get; set; }
}