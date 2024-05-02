using System.ComponentModel.DataAnnotations;

namespace Project.DTOs.Country;

public class CountryCreateDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
}
