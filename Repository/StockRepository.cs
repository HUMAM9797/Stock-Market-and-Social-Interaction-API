using Data;
using DTOs.Stock;
using Entities;
using interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class StockRepository(AppDbContext db) : IstockRepository
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
        return await db.Stock.ToListAsync();
    }

    public async Task<Stock?> GetStockByIdAsync(int id)
    {
        return await db.Stock.FindAsync(id);
    }

    public async Task<Stock?> UpdateStockAsync(Stock stockModel)
    {
        await db.SaveChangesAsync();
        return stockModel;
    }
}