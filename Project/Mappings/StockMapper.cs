using AutoMapper;
using Project.DTOs.Stock;
using Project.Models;

namespace Project.Mappings;

public class StockMapper : Profile
{
    public StockMapper()
    {
        CreateMap<Stock, StockReadDto>().ReverseMap();
        CreateMap<Stock, StockDetailDto>().ReverseMap();
        CreateMap<Stock, StockCreateDto>().ReverseMap();
        CreateMap<Stock, StockUpdateDto>().ReverseMap();
    }
}
