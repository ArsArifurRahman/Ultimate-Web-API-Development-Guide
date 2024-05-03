using AutoMapper;
using Project.DTOs.Stock;
using Project.Models;

namespace Project.Mappings;

public class StockMapper : Profile
{
    public StockMapper()
    {
        CreateMap<Stock, ReadDto>().ReverseMap();
        CreateMap<Stock, DetailDto>().ReverseMap();
        CreateMap<Stock, CreateDto>().ReverseMap();
        CreateMap<Stock, UpdateDto>().ReverseMap();
    }
}
