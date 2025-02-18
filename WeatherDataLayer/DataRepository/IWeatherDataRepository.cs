using WeatherDataLayer.DataEntity;

namespace WeatherDataLayer.DataRepository
{
    /// <summary>
    /// Interface for weather data repository to handle CRUD operations and calculations on weather data.
    /// </summary>
    public interface IWeatherDataRepository
    {
        /// <summary>
        /// Saves a list of weather forecasts asynchronously.
        /// </summary>
        /// <param name="WeatherForecast">List of weather forecasts to save.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SaveWeatherDataAsync(List<WeatherForecast> WeatherForecast);

        /// <summary>
        /// Retrieves all weather data asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a list of weather forecasts as the result.</returns>
        Task<List<WeatherForecast>> GetAllWeatherDataAsync();

        /// <summary>
        /// Calculates the average temperature from the weather data asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with the average temperature as the result.</returns>
        Task<double> GetAverageTemperatureAsync();

        /// <summary>
        /// Retrieves the maximum temperature from the weather data asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with the maximum temperature as the result.</returns>
        Task<double> GetMaxTemperatureAsync();

        /// <summary>
        /// Retrieves the minimum temperature from the weather data asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with the minimum temperature as the result.</returns>
        Task<double> GetMinTemperatureAsync();

        /// <summary>
        /// Provides a smart temperature recommendation based on the weather data asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with the smart temperature recommendation as the result.</returns>
        Task<double> GetSmartTemperRecommendationAsync();
    }
}