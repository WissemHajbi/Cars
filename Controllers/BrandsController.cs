using Microsoft.AspNetCore.Mvc;
using Cars.Data;
using Microsoft.EntityFrameworkCore;

namespace Cars.Controllers;
public class BrandsController : Controller
{
    private readonly CarsDbContext _context;
    public BrandsController(CarsDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var brands = await _context.Brands.ToListAsync();
        return View(brands);
    }
}