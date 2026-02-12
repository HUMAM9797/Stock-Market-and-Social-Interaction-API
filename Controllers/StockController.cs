using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using DTOs.Request;
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Controllers;
[ApiController]
[Route("api/[controller]")]
public class StockController :ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IMapper _Mapper;
    public StockController(AppDbContext db ,IMapper Mapper)
    {
        _db=db;
        _Mapper=Mapper;
    }
    
    [HttpGet]
    public ActionResult<StockRequest> Get()
    {
        var Stocks = _db.Stock.ToList();
        var stockRequest = _Mapper.Map<List<StockRequest>>(Stocks);
        return Ok(stockRequest);
    }

    [HttpGet("{id}")]
    public ActionResult<StockRequest> GetById( [FromRoute] int id)
    {
        var Stocks = _db.Stock.Find(id);
        if(Stocks == null)
            return NotFound();
        var stockRequest = _Mapper.Map<StockRequest>(Stocks);
        return Ok(stockRequest);
    }


}