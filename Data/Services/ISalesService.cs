using Cars.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Data.Services;

public interface ISalesService
{
    Task<IEnumerable<Sale>> GetAll();
    List<Sale> GetAllClean();
    Task<Sale> GetById(int id);
    Task<Sale> EditAsync(int id, Sale newsale);
    void AddAsync(Sale newsale);
}

