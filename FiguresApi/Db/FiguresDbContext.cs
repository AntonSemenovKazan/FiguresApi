
using Microsoft.EntityFrameworkCore;

namespace FiguresApi.Db
{
    public class FiguresDbContext : DbContext
    {
        public DbSet<Figure> Figures { get; set; }

        public DbSet<Coordinates> Coordinates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=figures.db");
    }
}