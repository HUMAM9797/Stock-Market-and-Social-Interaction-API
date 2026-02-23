using Data;
using Entities;
using Helpers;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repository;

public class StockRepository(AppDbContext db) : IStockRepository
{
    public async Task<Stock> CreateStockAsync(Stock stockModel)
    {
        await db.Stock.AddAsync(stockModel);
        await db.SaveChangesAsync();
        return stockModel;
    }

    public async Task<Stock> DeleteStockAsync(int id, Stock stockModel)
    {
        await db.Stock.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        await db.SaveChangesAsync();
        return stockModel;
    }

    public async Task<List<Stock>> GetStockAsync()
    {
        return await db.Stock.Include(c => c.Comment).ToListAsync();
    }

    public async Task<Stock?> GetStockByIdAsync(int id, QueryObject query)
    {
        var stocks = db.Stock.Include(c => c.Comment).AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Symbol))
        {
            stocks = stocks.Where(s => s.Symbol == query.Symbol);
        }

        if (!string.IsNullOrWhiteSpace(query.CompanyName))
        {
            stocks = stocks.Where(s => s.CompanyName == query.CompanyName);
        }

        return await stocks.FirstOrDefaultAsync(i => i.Id == id);
    }

    public Task<bool> StockExisit(int id)
    {
        return db.Stock.AnyAsync(s => s.Id == id);
    }

    public async Task<Stock?> UpdateStockAsync(Stock stockModel)

    {
        await db.SaveChangesAsync();
        return stockModel;
    }


}