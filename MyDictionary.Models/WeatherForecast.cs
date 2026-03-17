using Swashbuckle.AspNetCore.Annotations;

namespace MyDictionary.Models
{
    [SwaggerSchema("Weather forecast information for a specific date.")]
    public class WeatherForecast
    {
        [SwaggerSchema("The weather forecast date.")]
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}