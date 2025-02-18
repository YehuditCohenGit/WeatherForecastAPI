using System.Text.Json.Serialization;

namespace WeatherDataLayer.DataEntity
{
    public class WeatherForecastObject
    {
        [JsonPropertyName("daily")]
        public Daily DailyWeatherData { get; set; }
    }

    public class Daily
    {
        [JsonPropertyName("time")]
        public List<DateOnly> Time { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public List<double> TemperatureC { get; set; }
    }
}
