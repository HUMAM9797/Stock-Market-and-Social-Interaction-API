using asp.net_youtube_course.Entities;
using Microsoft.EntityFrameworkCore;

namespace asp.net_youtube_course.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions)
        {
        }

        public DbSet<Stock> Stock { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}