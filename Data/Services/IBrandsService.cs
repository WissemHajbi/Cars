using Cars.Models;

namespace Cars.Data.Services;

public interface IBrandsService
{
    Task<IEnumerable<Brand>> GetAll();
    Task<Brand> GetById(int id);
}