using Project.Models;

namespace Project.Repositories.Contracts;

public interface IStockContract
{
    Task<IEnumerable<Stock>> GetStocksAsync();
    Task<Stock> GetStockAsync(int id);
    Task<Stock> AddStockAsync(Stock stock);
    Task UpdateStockAsync(int id, Stock stock);
    Task DeleteStockAsync(int id);
    Task<bool> StockExistsAsync(int id);
}
