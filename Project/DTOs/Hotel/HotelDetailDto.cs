namespace Project.DTOs.Hotel;

public class HotelDetailDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public double Rating { get; set; }
    public int CountryId { get; set; }
}
