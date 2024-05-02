using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Hotel> Hotels { get; set; }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Country>()
            .HasData(
                new Country
                {
                    Id = 1,
                    Name = "France",
                    ShortName = "FR"
                },
                new Country
                {
                    Id = 2,
                    Name = "Italy",
                    ShortName = "IT"
                },
                new Country
                {
                    Id = 3,
                    Name = "Spain",
                    ShortName = "ES"
                },
                new Country
                {
                    Id = 4,
                    Name = "Germany",
                    ShortName = "DE"
                },
                new Country
                {
                    Id = 5,
                    Name = "United Kingdom",
                    ShortName = "UK"
                }
            );

        model.Entity<Hotel>()
            .HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Eiffel Tower Hotel",
                    Address = "Paris, France",
                    Rating = 4.8,
                    CountryId = 1
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Colosseum View",
                    Address = "Rome, Italy",
                    Rating = 4.5,
                    CountryId = 2
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Sagrada Familia Suites",
                    Address = "Barcelona, Spain",
                    Rating = 4.7,
                    CountryId = 3
                },
                new Hotel
                {
                    Id = 4,
                    Name = "Neuschwanstein Castle Lodge",
                    Address = "Fussen, Germany",
                    Rating = 4.2,
                    CountryId = 4
                },
                new Hotel
                {
                    Id = 5,
                    Name = "Big Ben Boutique",
                    Address = "London, United Kingdom",
                    Rating = 4.9,
                    CountryId = 5
                }
            );
    }
}
