using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Repositories.Contracts;

namespace Project.Repositories.Services;

public class StockService : IStockContract
{
    private readonly DataContext _context;

    public StockService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Stock>> GetStocksAsync()
    {
        return await _context.Stocks.ToListAsync();
    }

    public async Task<Stock> GetStockAsync(int id)
    {
        var stock = await _context.Stocks.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);

        if (stock == null)
        {
            throw new InvalidOperationException("Stock not found");
        }

        return stock;
    }


    public async Task<Stock> AddStockAsync(Stock stock)
    {
        if (stock == null)
        {
            throw new ArgumentNullException(nameof(stock));
        }

        await _context.Stocks.AddAsync(stock);
        await _context.SaveChangesAsync();

        return stock;
    }


    public async Task UpdateStockAsync(int id, Stock stock)
    {
        if (stock == null)
        {
            throw new ArgumentNullException(nameof(stock));
        }

        var existingStock = await GetStockAsync(id);

        if (existingStock == null)
        {
            throw new KeyNotFoundException("The existing stock with the given id was not found.");
        }

        _context.Entry(existingStock).CurrentValues.SetValues(stock);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteStockAsync(int id)
    {
        var stock = await GetStockAsync(id);

        if (stock == null)
        {
            throw new KeyNotFoundException("The stock with the given id was not found.");
        }

        _context.Stocks.Remove(stock);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> StockExistsAsync(int id)
    {
        return await GetStockAsync(id) != null;
    }
}
