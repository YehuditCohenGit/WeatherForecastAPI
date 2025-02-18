namespace WeatherDataLayer.DataManager
{

    /// <summary>
    /// Interface for managing weather data operations.
    /// </summary>
    public interface IWeatherDataManager
    {
        /// <summary>
        /// Asynchronously manages weather data.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task ManageDataAsync();
    }
}