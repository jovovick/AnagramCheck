using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using WeatherAPI;

namespace WeatherAPI.Tests;

public class WeatherForecastControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public WeatherForecastControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetTomorrow_ReturnsSuccessStatusCode()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/weatherforecast/tomorrow");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetTomorrow_ReturnsSingleWeatherForecast()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var weatherForecast = await client.GetFromJsonAsync<WeatherForecast>("/weatherforecast/tomorrow");

        // Assert
        Assert.NotNull(weatherForecast);
    }

    [Fact]
    public async Task GetTomorrow_ReturnsWeatherForecastForTomorrow()
    {
        // Arrange
        var client = _factory.CreateClient();
        var expectedDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1));

        // Act
        var weatherForecast = await client.GetFromJsonAsync<WeatherForecast>("/weatherforecast/tomorrow");

        // Assert
        Assert.NotNull(weatherForecast);
        Assert.Equal(expectedDate, weatherForecast.Date);
    }

    [Fact]
    public async Task GetTomorrow_ReturnsWeatherForecastWithValidTemperature()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var weatherForecast = await client.GetFromJsonAsync<WeatherForecast>("/weatherforecast/tomorrow");

        // Assert
        Assert.NotNull(weatherForecast);
        Assert.InRange(weatherForecast.TemperatureC, -20, 55);
    }

    [Fact]
    public async Task GetTomorrow_ReturnsWeatherForecastWithSummary()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var weatherForecast = await client.GetFromJsonAsync<WeatherForecast>("/weatherforecast/tomorrow");

        // Assert
        Assert.NotNull(weatherForecast);
        Assert.NotNull(weatherForecast.Summary);
        Assert.NotEmpty(weatherForecast.Summary);
    }
}