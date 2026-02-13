using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using DTOs.Stock;
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;

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
    public ActionResult<StockDto> GetStock()
    {
        var Stocks = _db.Stock.ToList();
        var StockDto = _Mapper.Map<List<StockDto>>(Stocks);
        return Ok(StockDto);
    }

    [HttpGet("{id}")]
    public ActionResult<StockDto> GetStockById([FromRoute] int id)
    {
        var Stocks = _db.Stock.Find(id);
        if (Stocks == null)
            return NotFound();
        var StockDto = _Mapper.Map<StockDto>(Stocks);
        return Ok(StockDto);
    }

    [HttpPost]
    public IActionResult CreateStock([FromBody] CreateStockDto StockDto)
    {
        var CreateStock = _Mapper.Map<Stock>(StockDto);
        _db.Stock.Add(CreateStock);
        _db.SaveChanges();

        return CreatedAtAction(nameof(GetStockById),new {id = CreateStock.Id},StockDto);
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateStock([FromRoute] id, [FromBody] UpdateStockDto StockDto)
    {
        var Stock = _db.Stock.FirstOrDefault(s => s.Id == id);
    }

}