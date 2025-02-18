using System.ComponentModel.DataAnnotations;

namespace WeatherDataLayer.DataEntity
{
    public class WeatherForecast
    {
        [Key]
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        public double TemperatureC { get; set; }
    }
}
