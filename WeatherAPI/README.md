# WeatherAPI

ASP.NET Core Web API project that provides weather forecast endpoints.

## Endpoints

### Get Weather Forecast
**GET** `/weatherforecast`

Returns a 5-day weather forecast starting from tomorrow.

**Response:**
```json
[
  {
    "date": "2025-12-17",
    "temperatureC": 25,
    "temperatureF": 77,
    "summary": "Warm"
  },
  ...
]
```

### Get Tomorrow's Weather Forecast
**GET** `/weatherforecast/tomorrow`

Returns the weather forecast for tomorrow.

**Response:**
```json
{
  "date": "2025-12-17",
  "temperatureC": 25,
  "temperatureF": 77,
  "summary": "Warm"
}
```

## Running the API

```bash
cd WeatherAPI
dotnet run
```

The API will be available at `https://localhost:5001` (or the port specified in launchSettings.json).

## Running Tests

```bash
cd WeatherAPI.Tests
dotnet test
```

## Building the Solution

```bash
dotnet build WeatherAPI.sln
```

## API Documentation

When running in Development mode, Swagger UI is available at `/swagger`.
