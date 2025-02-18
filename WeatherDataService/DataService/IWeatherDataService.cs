namespace WeatherDataServiceLayer.DataService
{
    /// <summary>
    /// Interface for weather data service to handle weather data operations and calculations.
    /// </summary>
    public interface IWeatherDataService
    {
        /// <summary>
        /// Calculates the average temperature from the weather data asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with the average temperature as the result.</returns>
        Task<double> GetAverageTemperatureAsync();

        /// <summary>
        /// Retrieves the minimum temperature from the weather data asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with the minimum temperature as the result.</returns>
        Task<double> GetMinTemperatureAsync();

        /// <summary>
        /// Retrieves the maximum temperature from the weather data asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with the maximum temperature as the result.</returns>
        Task<double> GetMaxTemperatureAsync();

        /// <summary>
        /// Provides a smart temperature recommendation based on the weather data asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with the smart temperature recommendation and air conditioner mode as the result.</returns>
        Task<(double Temper, AirConditionerMode Mode)> GetSmartTemperRecommendationAsync();
    }
}