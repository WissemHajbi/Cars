using Microsoft.EntityFrameworkCore;
using Cars.Models;

namespace Cars.Data;

public class CarsDbContext : DbContext
{
    public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
    {
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Sale> Sales { get; set; }

}