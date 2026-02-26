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
            },
            new Stock
            {
                Id = 5,
                Symbol = "NVDA",
                CompanyName = "NVIDIA Corp",
                Purches = 800.00m,
                LastDiv = 0.16m,
                Industry = "Technology",
                MarketCap = 2000000000000
            },
            new Stock
            {
                Id = 6,
                Symbol = "GOOGL",
                CompanyName = "Alphabet Inc",
                Purches = 140.00m,
                LastDiv = 0.0m,
                Industry = "Technology",
                MarketCap = 1700000000000
            },
            new Stock
            {
                Id = 7,
                Symbol = "META",
                CompanyName = "Meta Platforms",
                Purches = 480.00m,
                LastDiv = 0.50m,
                Industry = "Technology",
                MarketCap = 1200000000000
            },
            new Stock
            {
                Id = 8,
                Symbol = "BRK.B",
                CompanyName = "Berkshire Hathaway",
                Purches = 400.00m,
                LastDiv = 0.0m,
                Industry = "Financial Services",
                MarketCap = 900000000000
            },
            new Stock
            {
                Id = 9,
                Symbol = "LLY",
                CompanyName = "Eli Lilly",
                Purches = 750.00m,
                LastDiv = 1.30m,
                Industry = "Healthcare",
                MarketCap = 700000000000
            },
            new Stock
            {
                Id = 10,
                Symbol = "AVGO",
                CompanyName = "Broadcom Inc",
                Purches = 1200.00m,
                LastDiv = 5.25m,
                Industry = "Technology",
                MarketCap = 600000000000
            },
            new Stock
            {
                Id = 11,
                Symbol = "JPM",
                CompanyName = "JPMorgan Chase",
                Purches = 180.00m,
                LastDiv = 1.05m,
                Industry = "Financial Services",
                MarketCap = 500000000000
            },
            new Stock
            {
                Id = 12,
                Symbol = "V",
                CompanyName = "Visa Inc",
                Purches = 280.00m,
                LastDiv = 0.52m,
                Industry = "Financial Services",
                MarketCap = 550000000000
            },
            new Stock
            {
                Id = 13,
                Symbol = "WMT",
                CompanyName = "Walmart Inc",
                Purches = 60.00m,
                LastDiv = 0.20m,
                Industry = "Consumer Defensive",
                MarketCap = 450000000000
            },
            new Stock
            {
                Id = 14,
                Symbol = "XOM",
                CompanyName = "Exxon Mobil",
                Purches = 105.00m,
                LastDiv = 0.95m,
                Industry = "Energy",
                MarketCap = 400000000000
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
            },
            new Comments
            {
                Id = 6,
                Title = "AI Boom",
                Content = "NVIDIA is leading the AI revolution",
                MyProperty = new DateTime(2024, 2, 12),
                StockId = 5
            },
            new Comments
            {
                Id = 7,
                Title = "Search Monopoly",
                Content = "Google still dominates search",
                MyProperty = new DateTime(2024, 2, 12),
                StockId = 6
            },
            new Comments
            {
                Id = 8,
                Title = "Metaverse",
                Content = "Betting big on the future",
                MyProperty = new DateTime(2024, 2, 12),
                StockId = 7
            },
            new Comments
            {
                Id = 9,
                Title = "Warren Buffett",
                Content = "Safe haven asset",
                MyProperty = new DateTime(2024, 2, 12),
                StockId = 8
            },
            new Comments
            {
                Id = 10,
                Title = "Weight Loss",
                Content = "New drugs are game changers",
                MyProperty = new DateTime(2024, 2, 12),
                StockId = 9
            },
            new Comments
            {
                Id = 11,
                Title = "Semiconductors",
                Content = "Strong demand for chips",
                MyProperty = new DateTime(2024, 2, 12),
                StockId = 10
            },
            new Comments
            {
                Id = 12,
                Title = "Bank Leader",
                Content = "Best managed bank",
                MyProperty = new DateTime(2024, 2, 12),
                StockId = 11
            },
            new Comments
            {
                Id = 13,
                Title = "Payments",
                Content = "Cashless society beneficiary",
                MyProperty = new DateTime(2024, 2, 12),
                StockId = 12
            },
            new Comments
            {
                Id = 14,
                Title = "Retail Giant",
                Content = "Low prices everyday",
                MyProperty = new DateTime(2024, 2, 12),
                StockId = 13
            },
            new Comments
            {
                Id = 15,
                Title = "Oil & Gas",
                Content = "Energy demand remains high",
                MyProperty = new DateTime(2024, 2, 12),
                StockId = 14
            }
        );
    }
}
