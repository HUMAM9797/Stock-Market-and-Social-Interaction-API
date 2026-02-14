using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using DTOs.Stock;
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IMapper _Mapper;
    public StockController(AppDbContext db, IMapper Mapper)
    {
        _db = db;
        _Mapper = Mapper;
    }

    [HttpGet]
    public async Task<ActionResult<StockDto>> GetStock()
    {
        var Stocks = await _db.Stock.ToListAsync();
        var StockDto = _Mapper.Map<List<StockDto>>(Stocks);
        return Ok(StockDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StockDto>> GetStockById([FromRoute] int id)
    {
        var Stocks = await _db.Stock.FindAsync(id);
        if (Stocks == null)
            return NotFound();
        var StockDto = _Mapper.Map<StockDto>(Stocks);
        return Ok(StockDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStock([FromBody] CreateStockDto StockDto)
    {
        var CreateStock = _Mapper.Map<Stock>(StockDto);
        await _db.Stock.AddAsync(CreateStock);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStockById),new {id = CreateStock.Id},StockDto);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateStock([FromRoute] int id , [FromBody] UpdateStockDto StockDto)
    {
        var Stocks = await _db.Stock.FirstOrDefaultAsync(s => s.Id == id);
        if(Stocks == null) 
        {
            return NotFound();
        }
        _Mapper.Map(StockDto,Stocks);

            // Stocks.CompanyName = StockDto.CompanyName;
            // Stocks.Industry = StockDto.Industry;
            // Stocks.LastDiv = StockDto.LastDiv;
            // Stocks.Purches = StockDto.Purches;
            // Stocks.MarketCap = StockDto.MarketCap;
            // Stocks.Sympol = StockDto.Sympol;

        await _db.SaveChangesAsync();    
        return Ok(StockDto);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteStock([FromRoute] int id)
    {
        var Stocks = await _db.Stock.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        if(Stocks == null)
        {
            return NotFound();
        }
        Stocks.IsDeleted = true;
        await _db.SaveChangesAsync();
        return NoContent();
    }

}