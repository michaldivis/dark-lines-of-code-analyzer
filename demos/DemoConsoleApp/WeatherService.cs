using Bogus;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace DemoConsoleApp { 
    public class WeatherService
    {
	    private readonly ILogger<WeatherService> _logger;

	    public WeatherService(ILogger<WeatherService> logger)
	    {
		    _logger = logger;
	    }

        //An unnecesarly long method - should trigger "method too long"
        public void DoLotsOfThings()
	    {
		    var londonForecast = GetWeatherForCity("London");
		    _ = londonForecast.TemperatureF;

            var parisForecast = GetWeatherForCity("Paris");
            _ = parisForecast.TemperatureF;

		    var romeForecast = GetWeatherForCity("Rome");
            _ = romeForecast.TemperatureF;

		    Console.WriteLine(londonForecast);
            Console.WriteLine(parisForecast);
            Console.WriteLine(romeForecast);
            Console.WriteLine(londonForecast);
            Console.WriteLine(parisForecast);
            Console.WriteLine(romeForecast);
            Console.WriteLine(londonForecast);
            Console.WriteLine(parisForecast);
            Console.WriteLine(romeForecast);
            Console.WriteLine(londonForecast);
            Console.WriteLine(parisForecast);
            Console.WriteLine(romeForecast);
            Console.WriteLine(londonForecast);
            Console.WriteLine(parisForecast);
            Console.WriteLine(romeForecast);
            Console.WriteLine(londonForecast);
            Console.WriteLine(parisForecast);
            Console.WriteLine(romeForecast);
            Console.WriteLine(londonForecast);
            Console.WriteLine(parisForecast);
            Console.WriteLine(romeForecast);
            Console.WriteLine(londonForecast);
            Console.WriteLine(parisForecast);
            Console.WriteLine(romeForecast);
            Console.WriteLine(londonForecast);
            Console.WriteLine(parisForecast);
            Console.WriteLine(romeForecast);
            Console.WriteLine(londonForecast);
            Console.WriteLine(parisForecast);
            Console.WriteLine(romeForecast);
            Console.WriteLine(londonForecast);
            Console.WriteLine(parisForecast);
            Console.WriteLine(romeForecast);
            Console.WriteLine(londonForecast);
            Console.WriteLine(parisForecast);
            Console.WriteLine(romeForecast);
            Console.WriteLine(londonForecast);
            Console.WriteLine(parisForecast);
            Console.WriteLine(romeForecast);
            Console.WriteLine(londonForecast);
            Console.WriteLine(parisForecast);
            Console.WriteLine(romeForecast);
        }

        public WeatherForecast GetWeatherForCity(string city)
	    {
		    _logger.LogInformation("Retreieving weather forecast for {City}", city);
		    var forecast = GetRandomWeatherForCity(city);
            _logger.LogInformation("Weather forecast retreived: {Forecast}", forecast);
		    return forecast;
        }

	    private static WeatherForecast GetRandomWeatherForCity(string city)
	    {
		    var forecasts = new Faker<WeatherForecast>()
			    .RuleFor(a => a.TemperatureC, f => f.Random.Int(-10, 40))
			    .RuleFor(a => a.Date, f => DateTime.Now)
			    .RuleFor(a => a.City, f => city)
			    .RuleFor(a => a.Summary, f => f.Lorem.Word())
			    .Generate(1);
		    return forecasts.First();
        }
    }
}