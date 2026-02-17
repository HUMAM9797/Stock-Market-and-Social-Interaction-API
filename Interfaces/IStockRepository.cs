using AutoMapper;
using Controllers;
using Microsoft.AspNetCore.Mvc;
using DTOs.Stock;
using Entities;
namespace Interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetStockAsync();
    Task<Stock?> GetStockByIdAsync(int id);
    Task<Stock> CreateStockAsync(Stock stockModel);
    Task<Stock?> UpdateStockAsync(Stock stockModel);
    Task<Stock> DeleteStockAsync(int id, Stock stockModel);
}
