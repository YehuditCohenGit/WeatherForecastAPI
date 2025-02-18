using WeatherDataLayer.DataEntity;
using WeatherDataLayer.DataFetcher;
using WeatherDataLayer.DataRepository;

namespace WeatherDataLayer.DataManager
{
    /// <inheritdoc />
    public class WeatherDataManager : IWeatherDataManager
    {
        private readonly IWeatherDataFetcher _weatherDataFetcher;
        private readonly IWeatherDataRepository _weatherDataRepository;

        public WeatherDataManager(IWeatherDataFetcher weatherDataFetcher, IWeatherDataRepository weatherDataService)
        {
            _weatherDataFetcher = weatherDataFetcher ?? throw new ArgumentNullException(nameof(weatherDataFetcher));
            _weatherDataRepository = weatherDataService ?? throw new ArgumentNullException(nameof(weatherDataService));
        }

        /// <inheritdoc/>
        public async Task ManageDataAsync()
        {
            var weatherData = await _weatherDataFetcher.FetchWeatherDataAsync();
            var convertedData = ConvertDataToWeatherForecast(weatherData);
            await _weatherDataRepository.SaveWeatherDataAsync(convertedData);
        }

        private List<WeatherForecast> ConvertDataToWeatherForecast(WeatherForecastObject? WeatherForecastObject)
        {
            if (WeatherForecastObject == null)
            {
                throw new ArgumentNullException(nameof(WeatherForecastObject));
            }

            var WeatherForecastList = new List<WeatherForecast>();
            for (int i = 0; i < WeatherForecastObject.DailyWeatherData.Time.Count; i++)
            {
                WeatherForecastList.Add(
                new WeatherForecast
                {
                    Date = WeatherForecastObject.DailyWeatherData.Time[i],
                    TemperatureC = WeatherForecastObject.DailyWeatherData.TemperatureC[i]
                });
            }
            return WeatherForecastList;
        }
    }
}
