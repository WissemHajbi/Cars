using Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Data.Services;

public class BrandsService : IBrandsService
{
    private CarsDbContext _context;

    public BrandsService(CarsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Brand>> GetAll()
    {
        var Brands = await _context.Brands.ToListAsync();
        return Brands;
    }

    public async Task<Brand> GetById(int id)
    {
        return await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
    }
}