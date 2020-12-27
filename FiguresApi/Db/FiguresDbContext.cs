
using Microsoft.EntityFrameworkCore;

namespace FiguresApi.Db
{
    public class FiguresDbContext : DbContext
    {
        private readonly IDbSettings dbSettings;

        public FiguresDbContext(IDbSettings dbSettings)
        {
            this.dbSettings = dbSettings;
        }

        public DbSet<Figure> Figures { get; set; }

        public DbSet<Coordinates> Coordinates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(dbSettings.ConnectionString);
    }
}