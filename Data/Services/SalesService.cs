using Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Data.Services;

public class SalesService : ISalesService
{
    private CarsDbContext _context;

    public SalesService(CarsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Sale>> GetAll()
    {
        var sales = await _context.Sales.Include(n => n.car).Include(n => n.car.brand).ToListAsync();
        return sales;
    }

    public List<Sale> GetAllClean()
    {
        var sales = _context.Sales.ToList();
        return sales;
    }

    public async Task<Sale> GetById(int id)
    {
        return await _context.Sales.FirstOrDefaultAsync(x => x.Id == id);
    }

}