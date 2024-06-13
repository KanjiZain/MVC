var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var weatherForecasts = new List<WeatherForecast>();

app.MapGet("/weatherforecast", () =>
{
    return weatherForecasts;
});

app.MapGet("/weatherforecast/{id}", (int id) =>
{
    return weatherForecasts.Find(f => f.Id == id);
});

app.MapPost("/weatherforecast", (WeatherForecast forecast) =>
{
    forecast.Id = weatherForecasts.Count + 1;
    weatherForecasts.Add(forecast);
    return Results.Created($"/weatherforecast/{forecast.Id}", forecast);
});

app.MapPut("/weatherforecast/{id}", (int id, WeatherForecast forecast) =>
{
    var existingForecast = weatherForecasts.Find(f => f.Id == id);
    if (existingForecast != null)
    {
        existingForecast.Date = forecast.Date;
        existingForecast.TemperatureC = forecast.TemperatureC;
        existingForecast.Summary = forecast.Summary;
    }
    return Results.Ok();
});

app.MapDelete("/weatherforecast/{id}", (int id) =>
{
    var existingForecast = weatherForecasts.Find(f => f.Id == id);
    if (existingForecast != null)
    {
        weatherForecasts.Remove(existingForecast);
    }
    return Results.Ok();
});

app.Run();

internal record WeatherForecast
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}