using AutoMapper;
using DTOs.Comments;
using DTOs.Stock;
using Entities;

namespace Helpers;

public class Mappingprofiles : Profile
{
    public Mappingprofiles()
    {
        CreateMap<Stock, StockDto>();
        CreateMap<Stock, CreateStockDto>();
        CreateMap<CreateStockDto, Stock>();
        CreateMap<UpdateStockDto, Stock>();
        CreateMap<Stock, CreateStockDto>();
        CreateMap<Comments, CommentsDto>();
    }
}