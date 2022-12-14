using Microsoft.AspNetCore.Mvc;
using Cars.Data;
using Microsoft.EntityFrameworkCore;
using Cars.Data.Services;

namespace Cars.Controllers;
public class BrandsController : Controller
{
    private readonly IBrandsService _service;
    public BrandsController(IBrandsService service)
    {
        _service = service;
    }
    public async Task<IActionResult> Index()
    {
        var brands = await _service.GetAll();
        return View(brands);
    }

    public async Task<IActionResult> Details(int id)
    {
        var brand = await _service.GetById(id);

        if (brand == null) return View("Empty");
        return View(brand);
    }
}