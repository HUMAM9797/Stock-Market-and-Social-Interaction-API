using Data;
using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Stock?> GetStockByIdAsync(int id)
    {
        return await db.Stock.Include(c => c.Comment).FirstOrDefaultAsync(i => i.Id == id);
    }

    public  Task<bool> StockExisit(int id)
    {
        return  db.Stock.AnyAsync(s => s.Id == id);
    }

    public async Task<Stock?> UpdateStockAsync(Stock stockModel)

    {
        await db.SaveChangesAsync();
        return stockModel;
    }


}