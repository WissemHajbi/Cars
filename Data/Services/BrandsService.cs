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

    public void Add(Brand brand)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Brand>> GetAll()
    {
        var Brands = await _context.Brands.ToListAsync();
        return Brands;
    }

    public Brand GetById()
    {
        throw new NotImplementedException();
    }

    public Brand Update(int id, Brand brand)
    {
        throw new NotImplementedException();
    }
}