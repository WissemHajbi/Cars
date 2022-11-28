using Microsoft.AspNetCore.Mvc;
using Cars.Data;
using Microsoft.EntityFrameworkCore;

namespace Cars.Controllers;
public class CarsController : Controller
{
    private readonly CarsDbContext _context;
    public CarsController(CarsDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var cars = await _context.Cars.ToListAsync();
        return View();
    }
}