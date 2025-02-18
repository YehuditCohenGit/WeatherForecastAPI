using WeatherDataLayer.DataEntity;

namespace WeatherDataLayer.DataFetcher
{
    /// <summary>
    /// Interface for fetching weather data.
    /// </summary>
    public interface IWeatherDataFetcher
    {
        /// <summary>
        /// Fetches the weather data asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the weather forecast object.</returns>
        Task<WeatherForecastObject?> FetchWeatherDataAsync();
    }
}