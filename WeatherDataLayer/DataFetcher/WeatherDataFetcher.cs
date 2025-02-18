using WeatherDataLayer.DataEntity;
using WeatherDataLayer.Utils;

namespace WeatherDataLayer.DataFetcher
{
    /// <inheritdoc />
    public class WeatherDataFetcher : IWeatherDataFetcher
    {
        private readonly HttpClient _httpClient;
        private const string WeatherAPI = "https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&daily=temperature_2m_max,wind_speed_10m_max&timezone=Europe%2FBerlin&past_days=31&forecast_days=1";

        public WeatherDataFetcher(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <inheritdoc />
        public async Task<WeatherForecastObject?> FetchWeatherDataAsync()
        {
            var response = await _httpClient.GetAsync(WeatherAPI);
            response.EnsureSuccessStatusCode();
            var dataAsString = await response.Content.ReadAsStringAsync();
            var weatherData = WeatherForecastExtensions.ConvertFromJson(dataAsString);

            return weatherData;
        }
    }
}

