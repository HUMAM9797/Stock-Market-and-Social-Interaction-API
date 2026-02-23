using Entities;
using Helpers;
namespace Interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetStockAsync();
    Task<Stock?> GetStockByIdAsync(int id, QueryObject query);
    Task<Stock> CreateStockAsync(Stock stockModel);
    Task<Stock?> UpdateStockAsync(Stock stockModel);
    Task<Stock> DeleteStockAsync(int id, Stock stockModel);
    Task<bool> StockExisit(int id);
}
