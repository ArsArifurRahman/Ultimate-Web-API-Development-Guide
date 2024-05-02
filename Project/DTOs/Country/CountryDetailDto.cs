using Project.DTOs.Hotel;

namespace Project.DTOs.Country;

public class CountryDetailDto : BaseDto
{
    public int Id { get; set; }
    public List<HotelDetailDto>? Hotels { get; set; }
}
