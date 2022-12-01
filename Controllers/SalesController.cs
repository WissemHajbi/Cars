using Microsoft.AspNetCore.Mvc;
using Cars.Data;
using Microsoft.EntityFrameworkCore;

namespace Cars.Controllers;
public class SalesController : Controller
{
    private readonly CarsDbContext _context;
    public SalesController(CarsDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        // All Sales
        var sales = await _context.Sales.ToListAsync();

        // Top Sellers
        List<int> Allids = new List<int>();
        List<int> Minids = new List<int>();

        foreach (var sale in sales)
        {
            Allids.Add(sale.Id);
        }

        for (int i = 0; i < 3; i++)
        {
            int id = Allids.Min();
            Minids.Add(id);
            Allids.Remove(id);
        }

        Console.WriteLine(Minids);
        Console.WriteLine("aaaaaaa");


        ViewData["TopSellersId"] = Minids;

        return View(sales);
    }
}