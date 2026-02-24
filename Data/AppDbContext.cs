using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions)
    {
    }

    public DbSet<Stock> Stock { get; set; }
    public DbSet<Comments> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Stock>().HasQueryFilter(filter: s => !s.IsDeleted);
        modelBuilder.Entity<Comments>().HasQueryFilter(filter: c => !c.IsDeleted);

        modelBuilder.Entity<Stock>().HasData(
            new Stock
            {
                Id = 1,
                Symbol = "AAPL",
                CompanyName = "APPLE INC",
                Purches = 250.00m,
                LastDiv = 2.5m,
                Industry = "Technology",
                MarketCap = 3000000000
            },
            new Stock
            {
                Id = 2,
                Symbol = "MSFT",
                CompanyName = "MICROSOFT",
                Purches = 150.00m,
                LastDiv = 3.0m,
                Industry = "Technology",
                MarketCap = 2500000000
            },
            new Stock
            {
                Id = 3,
                Symbol = "TSLA",
                CompanyName = "Tesla Inc",
                Purches = 180.00m,
                LastDiv = 0.0m,
                Industry = "Automotive",
                MarketCap = 600000000000
            },
            new Stock
            {
                Id = 4,
                Symbol = "AMZN",
                CompanyName = "Amazon.com",
                Purches = 140.00m,
                LastDiv = 0.0m,
                Industry = "Technology",
                MarketCap = 1500000000000
            }
        );

        modelBuilder.Entity<Comments>().HasData(
            new Comments
            {
                Id = 1,
                Title = "Great company",
                Content = "Long term hold",
                MyProperty = new DateTime(2024, 2, 12),
                StockId = 1
            },
            new Comments
            {
                Id = 2,
                Title = "Dividends",
                Content = "Dividends are okay, could be better",
                MyProperty = new DateTime(2024, 2, 12),
                StockId = 1
            },
            new Comments
            {
                Id = 3,
                Title = "Cloud King",
                Content = "Azure is growing fast",
                MyProperty = new DateTime(2024, 2, 12),
                StockId = 2
            },
            new Comments
            {
                Id = 4,
                Title = "Volatile",
                Content = "High risk high reward",
                MyProperty = new DateTime(2024, 2, 12),
                StockId = 3
            },
            new Comments
            {
                Id = 5,
                Title = "AWS",
                Content = "AWS is the money maker",
                MyProperty = new DateTime(2024, 2, 12),
                StockId = 4
            }
        );
    }
}
