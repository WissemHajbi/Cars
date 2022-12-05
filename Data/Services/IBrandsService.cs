using Cars.Models;

namespace Cars.Data.Services;

public interface IBrandsService
{
    Task<IEnumerable<Brand>> GetAll();
    Brand GetById();
    void Add(Brand brand);
    Brand Update(int id, Brand brand);
    void Delete(int id);
}