using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WeatherDataLayer.DataEntity;

namespace WeatherDataLayer
{
    public class WeatherDbContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecastTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlConnectionSB = new SqlConnectionStringBuilder
            {
                DataSource = "tcp:weather-data-sql-server-il.database.windows.net,1433",
                InitialCatalog = "WeatherData",
                UserID = "UserID",
                Password = "Password",
                ConnectRetryCount = 3,
                ConnectRetryInterval = 10,
                IntegratedSecurity = false,
                Encrypt = true,
                ConnectTimeout = 30
            };

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(sqlConnectionSB.ToString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TemperatureC).IsRequired();
                entity.Property(e => e.Date).IsRequired();
            });
        }
    }
}
