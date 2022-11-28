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
        var sales = await _context.Sales.ToListAsync();
        return View();
    }
}