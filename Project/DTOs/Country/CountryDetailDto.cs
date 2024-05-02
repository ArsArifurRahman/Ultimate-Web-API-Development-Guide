using Project.DTOs.Hotel;

namespace Project.DTOs.Country;

public class CountryDetailDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public List<HotelDetailDto>? Hotels { get; set; }
}
