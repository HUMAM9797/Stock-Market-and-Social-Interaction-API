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
                LastDiv =2.5m,
                Industry = "Technology",
                MarketCap = 3000000000
            },
            new Stock
            {
                Id = 2,
                Symbol = "MSFT",
                CompanyName = "MICROSOFT",
                Purches = 150.00m,
                LastDiv =3.0m,
                Industry = "Technology",
                MarketCap = 2500000000
            }
        );
    }
}


