using Microsoft.AspNetCore.Mvc;
using WeatherDataServiceLayer.DataService;

namespace WeatherAPIService.Controllers
{
    /// <summary>
    /// Controller for handling weather forecast related requests.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherDataService _weatherDataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
        /// </summary>
        /// <param name="weatherDataService">The weather data service.</param>
        /// <exception cref="ArgumentNullException">Thrown when weatherDataService is null.</exception>
        public WeatherForecastController(IWeatherDataService weatherDataService)
        {
            _weatherDataService = weatherDataService ?? throw new ArgumentNullException(nameof(weatherDataService));
        }

        /// <summary>
        /// Gets the average temperature.
        /// </summary>
        /// <returns>The average temperature.</returns>
        [HttpGet("average-temperature")]
        public async Task<ActionResult<double>> GetAverageTemperature()
        {
            try
            {
                var averageTemperature = await _weatherDataService.GetAverageTemperatureAsync();
                return Ok(averageTemperature);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Gets the minimum temperature.
        /// </summary>
        /// <returns>The minimum temperature.</returns>
        [HttpGet("min-temperature")]
        public async Task<ActionResult<double>> GetMinTemperature()
        {
            try
            {
                var minTemperature = await _weatherDataService.GetMinTemperatureAsync();
                return Ok(minTemperature);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Gets the maximum temperature.
        /// </summary>
        /// <returns>The maximum temperature.</returns>
        [HttpGet("max-temperature")]
        public async Task<ActionResult<double>> GetMaxTemperature()
        {
            try
            {
                var maxTemperature = await _weatherDataService.GetMaxTemperatureAsync();
                return Ok(maxTemperature);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Gets the smart temperature recommendation.
        /// </summary>
        /// <returns>The smart temperature recommendation.</returns>
        [HttpGet("smart-temperature")]
        public async Task<ActionResult<(double, AirConditionerMode)>> GetSmartTemperRecommendationAsync()
        {
            try
            {
                var recommendedTempe = await _weatherDataService.GetSmartTemperRecommendationAsync();
                return Ok(recommendedTempe.ToString());
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
