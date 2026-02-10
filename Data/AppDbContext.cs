using Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions contextOptions ) : base(contextOptions)
    {
    }
        public DbSet<Stock> Stock {get; set;}
        public DbSet<Comments> Comments {get; set;}
}