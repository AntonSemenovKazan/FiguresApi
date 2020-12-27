

using Microsoft.Extensions.Configuration;

namespace FiguresApi.Db
{
    public class DbSettings : IDbSettings
    {
        public DbSettings(IConfiguration configuration)
        {
            var dbName = configuration["Db:Name"];
            ConnectionString = $"Data Source={dbName}";
        }
        public string ConnectionString { get; set; }
    }
}