using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DTOs.Stocks;
using Entities;
using Interfaces;
using Helpers;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockController(IMapper mapper, IStockRepository stockRepo) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<StockDto>>> GetStock([FromQuery] QueryObject query)
    {
        var stockModel = await stockRepo.GetStockAsync(query);
        mapper.Map<List<StockDto>>(stockModel);
        return Ok(stockModel);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<StockDto>> GetStockById([FromRoute] int id)
    {
        var stockModel = await stockRepo.GetStockByIdAsync(id);
        if (stockModel == null)
            return NotFound();
        mapper.Map<StockDto>(stockModel);
        return Ok(stockModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStock([FromBody] CreateStockDto stockDto)
    {
        var stockModel = mapper.Map<Stock>(stockDto);
        await stockRepo.CreateStockAsync(stockModel);

        return CreatedAtAction(nameof(GetStockById), new { id = stockModel.Id }, mapper.Map<StockDto>(stockModel));
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateStock([FromRoute] int id, [FromBody] UpdateStockDto stockDto)
    {
        var stock = await stockRepo.GetStockByIdAsync(id);
        if (stock == null)
        {
            return NotFound();
        }
        mapper.Map(stockDto, stock);
        await stockRepo.UpdateStockAsync(stock);
        return Ok(mapper.Map<UpdateStockDto>(stock));
    }

    [HttpDelete]
    [Route("{id:int}")]
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