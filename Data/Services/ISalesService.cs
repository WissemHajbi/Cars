using Cars.Models;

namespace Cars.Data.Services;

public interface ISalesService
{
    Task<IEnumerable<Sale>> GetAll();
    List<Sale> GetAllClean();
}