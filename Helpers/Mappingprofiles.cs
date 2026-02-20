using AutoMapper;
using DTOs.Comments;
using DTOs.Stocks;
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
        CreateMap<Comments, CommentsDto>();
        CreateMap<CommentsDto, Comments>();
        CreateMap<CreateCommentsDto, Comments>();
    }
}