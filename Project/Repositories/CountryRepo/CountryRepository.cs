using Microsoft.EntityFrameworkCore;
using Project.Contracts.CountryContract;
using Project.Data;
using Project.Models;

namespace Project.Repositories.CountryRepo;

public class CountryRepository : Repository<Country>, ICountryRepository
{
    private readonly DataContext _context;

    public CountryRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Country> GetDetails(int id)
    {
        var country = await _context.Countries.Include(x => x.Hotels).FirstOrDefaultAsync(x => x.Id == id);

        if (country != null)
        {
            return country;
        }
        else
        {
            throw new Exception("Country with id " + id + " not found");
        }
    }
}
