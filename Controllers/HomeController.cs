using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cars.Models;
using Cars.Data;
using Microsoft.EntityFrameworkCore;

namespace Cars.Controllers;

public class HomeController : Controller
{
    private readonly CarsDbContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, CarsDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var sales = await _context.Sales.ToListAsync();

        // Top 3 Sellers
        List<Sale> MinSales = new List<Sale>();
        var Nsales = await _context.Sales.ToListAsync();

        for (int i = 0; i < 3; i++)
        {
            var MinSale = Nsales.First(x => x.capacity == Nsales.Min(y => y.capacity));
            MinSales.Add(MinSale);
            Nsales.Remove(MinSale);
        }

        ViewData["TopSellers"] = MinSales;

        return View(sales);
    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
