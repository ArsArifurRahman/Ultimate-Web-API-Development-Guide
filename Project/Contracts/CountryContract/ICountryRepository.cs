using Project.Models;

namespace Project.Contracts.CountryContract;

public interface ICountryRepository : IRepository<Country>
{
    Task<Country> GetDetails(int id);
}
