using Microsoft.AspNetCore.Mvc;
using Cars.Data;
using Microsoft.EntityFrameworkCore;
using Cars.Models;
using Cars.Data.Services;

namespace Cars.Controllers;
public class SalesController : Controller
{
    private CarsDbContext _c;
    private readonly ISalesService _service;
    public SalesController(ISalesService service, CarsDbContext c)
    {
        _c = c;
        _service = service;
    }
    public async Task<IActionResult> Index()
    {
        var sales = await _service.GetAll();

        // Top 3 Sellers
        List<Sale> MinSales = new List<Sale>();
        var Nsales = _service.GetAllClean();

        for (int i = 0; i < 3; i++)
        {
            var MinSale = Nsales.First(x => x.capacity == Nsales.Min(y => y.capacity));
            MinSales.Add(MinSale);
            Nsales.Remove(MinSale);
        }

        ViewData["TopSellers"] = MinSales;

        return View(sales);
    }

    public async Task<IActionResult> Details(int id)
    {
        var Sale = await _service.GetById(id);

        if (Sale == null) return View("Empty");
        return View(Sale);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var Sale = await _service.GetById(id);

        if (Sale == null) return View("Empty");
        return View(Sale);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Sale sale)
    {
        if (!ModelState.IsValid)
        {
            return View(sale);
        }
        await _service.EditAsync(id, sale);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add([Bind("Name,Description,Price,Distance,ImageUrl,Categories,CarId")] Sale newsale)
    {

        if (ModelState.IsValid)
        {
            return View(newsale);
        }
        _service.AddAsync(newsale);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int Id)
    {
        var Sale = await _service.GetById(Id);

        if (Sale == null) return View("Empty");
        return View(Sale);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int Id)
    {
        await _service.DeleteAsync(Id);
        return RedirectToAction(nameof(Index));
    }
}