using AutoMapper;
using DTOs.Request;
using Entities;

namespace Helpers;

public class Mappingprofiles : Profile
{
    public Mappingprofiles()
    {
        CreateMap<Stock, StockRequest>();
    }
}