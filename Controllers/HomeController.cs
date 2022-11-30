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
        Console.Write(sales[3].Name);
        return View(sales);
    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
