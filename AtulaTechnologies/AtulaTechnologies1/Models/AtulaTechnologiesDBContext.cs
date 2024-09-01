using Microsoft.EntityFrameworkCore;
using AtulaTechnologies1.Models;

namespace AtulaTechnologies1.Models
{
    public class AtulaTechnologiesDBContext : DbContext
    {
        public AtulaTechnologiesDBContext(DbContextOptions<AtulaTechnologiesDBContext> options)
        : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
