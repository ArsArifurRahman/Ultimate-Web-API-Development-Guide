using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Comment> Comments { get; set; }
    public DbSet<Stock> Stocks { get; set; }

    protected override void OnModelCreating(ModelBuilder model)
    {
        // Define the relationship
        model.Entity<Comment>()
            .HasOne(c => c.Stock)
            .WithMany(s => s.Comments)
            .HasForeignKey(c => c.StockId);

        // Seed the Stock data
        model.Entity<Stock>().HasData(
            new Stock
            {
                Id = 1,
                Symbol = "AAPL",
                Company = "Apple Inc.",
                Purchase = 150.00m,
                LastDividend = 0.82m,
                Industry = "Technology",
                MarketCapital = 2000000000
            },
            new Stock
            {
                Id = 2,
                Symbol = "GOOGL",
                Company = "Alphabet Inc.",
                Purchase = 2500.00m,
                LastDividend = 10.60m,
                Industry = "Technology",
                MarketCapital = 1800000000
            },
            new Stock
            {
                Id = 3,
                Symbol = "MSFT",
                Company = "Microsoft Corporation",
                Purchase = 300.00m,
                LastDividend = 2.04m,
                Industry = "Technology",
                MarketCapital = 1600000000
            },
            new Stock
            {
                Id = 4,
                Symbol = "AMZN",
                Company = "Amazon.com, Inc.",
                Purchase = 3300.00m,
                LastDividend = 0m,
                Industry = "E-commerce",
                MarketCapital = 1700000000
            },
            new Stock
            {
                Id = 5,
                Symbol = "TSLA",
                Company = "Tesla, Inc.",
                Purchase = 700.00m,
                LastDividend = 0m,
                Industry = "Automotive",
                MarketCapital = 800000000
            }
        );

        // Seed the Comment data
        model.Entity<Comment>().HasData(
            new Comment
            {
                Id = 1,
                Title = "Great stock",
                Description = "This is a great stock to invest in.",
                CreatedOn = DateTimeOffset.Now,
                StockId = 1
            },
            new Comment
            {
                Id = 2,
                Title = "Overpriced",
                Description = "I think this stock is overpriced.",
                CreatedOn = DateTimeOffset.Now,
                StockId = 2
            },
            new Comment
            {
                Id = 3,
                Title = "Undervalued",
                Description = "This stock is undervalued.",
                CreatedOn = DateTimeOffset.Now,
                StockId = 3
            },
            new Comment
            {
                Id = 4,
                Title = "High risk",
                Description = "Investing in this stock is high risk.",
                CreatedOn = DateTimeOffset.Now,
                StockId = 4
            },
            new Comment
            {
                Id = 5,
                Title = "Good dividend",
                Description = "This stock pays a good dividend.",
                CreatedOn = DateTimeOffset.Now,
                StockId = 5
            }
        );
    }
}
