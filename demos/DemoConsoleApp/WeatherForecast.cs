namespace DemoConsoleApp;

public class WeatherForecast
{
    public string? City { get; init; }
    public DateTime Date { get; init; }
    public int TemperatureC { get; init; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string? Summary { get; init; }
}
