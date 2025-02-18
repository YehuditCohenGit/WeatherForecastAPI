using System.Text.Json.Serialization;
using System.Text.Json;
using WeatherDataLayer.DataEntity;

namespace WeatherDataLayer.Utils
{
    public static class WeatherForecastExtensions
    {
        /// <summary>
        /// Converts a JSON string to a WeatherForecastObject.
        /// </summary>
        /// <param name="json">The JSON string representing the weather forecast data.</param>
        /// <returns>A WeatherForecastObject instance or null if the conversion fails.</returns>
        public static WeatherForecastObject? ConvertFromJson(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return JsonSerializer.Deserialize<WeatherForecastObject>(json, options);
        }
    }
}
