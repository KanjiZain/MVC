using Microsoft.EntityFrameworkCore;
using Project.API.Models;

namespace Project.API.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
    }
}
