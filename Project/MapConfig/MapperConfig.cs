using AutoMapper;
using Project.DTOs.Country;
using Project.DTOs.Hotel;
using Project.Models;

namespace Project.MapConfig;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Country, CountryReadDto>().ReverseMap();
        CreateMap<Country, CountryDetailDto>().ReverseMap();
        CreateMap<Country, CountryCreateDto>().ReverseMap();
        CreateMap<Country, CountryUpdateDto>().ReverseMap();

        CreateMap<Hotel, HotelDetailDto>().ReverseMap();
    }
}
