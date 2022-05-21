using Kolmeo.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace Kolmeo.DataServices.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
