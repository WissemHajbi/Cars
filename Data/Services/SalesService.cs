using Cars.Models;
using Microsoft.AspNetCore.Mvc;
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

    public async Task<Sale> EditAsync(int id, Sale newsale)
    {
        _context.Update(newsale);
        await _context.SaveChangesAsync();
        return newsale;
    }

    public async void AddAsync(Sale newsale)
    {
        newsale.StartDate = DateTime.Today;
        newsale.EndDate = DateTime.Today.AddDays(30);
        newsale.capacity = 12;

        await _context.Sales.AddAsync(newsale);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int Id)
    {
        _context.Sales.Remove(await _context.Sales.FirstOrDefaultAsync(x => x.Id == Id));
        await _context.SaveChangesAsync();
    }

}