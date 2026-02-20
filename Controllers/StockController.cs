using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using DTOs.Stocks;
using Entities;
using Interfaces;
using Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockController(IMapper mapper, IStockRepository stockRepo) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<StockDto>>> GetStock()
    {
        var stocks = await stockRepo.GetStockAsync();
        var stockDto = mapper.Map<List<StockDto>>(stocks);
        return Ok(stockDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StockDto>> GetStockById([FromRoute] int id)
    {
        var stock = await stockRepo.GetStockByIdAsync(id);
        if (stock == null)
            return NotFound();
        var stockDto = mapper.Map<StockDto>(stock);
        return Ok(stockDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStock([FromBody] CreateStockDto stockDto)
    {
        var stockModel = mapper.Map<Stock>(stockDto);
        await stockRepo.CreateStockAsync(stockModel);

        return CreatedAtAction(nameof(GetStockById), new { id = stockModel.Id }, mapper.Map<StockDto>(stockModel));
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateStock([FromRoute] int id, [FromBody] UpdateStockDto stockDto)
    {
        var stock = await stockRepo.GetStockByIdAsync(id);
        if (stock == null)
        {
            return NotFound();
        }
        mapper.Map(stockDto, stock);
        await stockRepo.UpdateStockAsync(stock);
        return Ok(mapper.Map<StockDto>(stock));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteStock([FromRoute] int id)
    {
        var stock = await stockRepo.GetStockByIdAsync(id);
        if (stock == null)
        {
            return NotFound();
        }
        stock.IsDeleted = true;
        await stockRepo.DeleteStockAsync(id, stock);
        return NoContent();
    }

}