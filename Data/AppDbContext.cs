using asp.net_youtube_course.Migrations;
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
    }
    } 


