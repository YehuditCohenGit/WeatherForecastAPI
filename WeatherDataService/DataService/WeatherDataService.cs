using WeatherDataLayer.DataRepository;

namespace WeatherDataServiceLayer.DataService
{
    public class WeatherDataService : IWeatherDataService
    {
        private readonly IWeatherDataRepository _weatherDataRepository;

        public WeatherDataService(IWeatherDataRepository weatherDataRepository)
        {
            _weatherDataRepository = weatherDataRepository ?? throw new ArgumentNullException(nameof(weatherDataRepository));
        }

        /// <inheritdoc />
        public async Task<double> GetAverageTemperatureAsync()
        {
            return await _weatherDataRepository.GetAverageTemperatureAsync();
        }

        /// <inheritdoc />
        public async Task<double> GetMinTemperatureAsync()
        {
            return await _weatherDataRepository.GetMinTemperatureAsync();
        }

        /// <inheritdoc />
        public async Task<double> GetMaxTemperatureAsync()
        {
            return await _weatherDataRepository.GetMaxTemperatureAsync();
        }

        /// <inheritdoc />
        public async Task<(double Temper, AirConditionerMode Mode)> GetSmartTemperRecommendationAsync()
        {
            var temper = await _weatherDataRepository.GetSmartTemperRecommendationAsync();
            var airConditionerMode = AirConditionerMode.Cold;
            switch (temper)
            {
                case < 15:
                    airConditionerMode = AirConditionerMode.Hot;
                    temper += 12;
                    break;
                case < 25:
                    airConditionerMode = AirConditionerMode.Fan;
                    break;
                default:
                    temper -= 5;
                    break;
            }

            return (temper, airConditionerMode);
        }
    }

    public enum AirConditionerMode
    {
        Cold,
        Hot,
        Fan
    }
}
