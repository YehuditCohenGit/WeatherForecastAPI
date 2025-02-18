using Microsoft.EntityFrameworkCore;
using WeatherDataLayer.DataEntity;

namespace WeatherDataLayer.DataRepository
{
    /// <inheritdoc />
    public class WeatherDataRepository : IWeatherDataRepository
    {
        private readonly WeatherDbContext _context;

        public WeatherDataRepository(WeatherDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task SaveWeatherDataAsync(List<WeatherForecast> WeatherForecasts)
        {
            try
            {
                await _context.WeatherForecastTable.AddRangeAsync(WeatherForecasts);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("An error occurred while saving weather data.", ex);
            }
        }

        /// <inheritdoc />
        public async Task<List<WeatherForecast>> GetAllWeatherDataAsync()
        {
            try
            {
                return await _context.WeatherForecastTable.FromSqlRaw("SELECT * FROM WeatherForecastTable").ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all weather data.", ex);
            }
        }

        /// <inheritdoc />
        public async Task<double> GetAverageTemperatureAsync()
        {
            try
            {
                return await ExecuteScalarQueryAsync("SELECT AVG(TemperatureC) AS TemperatureC FROM WeatherForecastTable");
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while calculating the average temperature.", ex);
            }
        }

        /// <inheritdoc />
        public async Task<double> GetMinTemperatureAsync()
        {
            try
            {
                return await ExecuteScalarQueryAsync("SELECT MIN(TemperatureC) AS TemperatureC FROM WeatherForecastTable");

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the minimum temperature.", ex);
            }
        }

        /// <inheritdoc />
        public async Task<double> GetMaxTemperatureAsync()
        {
            try
            {
                return await ExecuteScalarQueryAsync("SELECT MAX(TemperatureC) AS TemperatureC FROM WeatherForecastTable");

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the maximum temperature.", ex);
            }
        }

        /// <inheritdoc />
        public async Task<double> GetSmartTemperRecommendationAsync()
        {
            try
            {
                var res = await _context.WeatherForecastTable.FromSqlRaw("SELECT TOP 1 * FROM WeatherForecastTable ORDER BY Date DESC").FirstOrDefaultAsync();
                return res.TemperatureC;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the smart temperature recommendation.", ex);
            }
        }

        private async Task<double> ExecuteScalarQueryAsync(string query)
        {
            try
            {
                return await _context.WeatherForecastTable
                    .FromSqlRaw(query)
                    .Select(w => w.TemperatureC)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the query.", ex);

            }
        }
    }
}
