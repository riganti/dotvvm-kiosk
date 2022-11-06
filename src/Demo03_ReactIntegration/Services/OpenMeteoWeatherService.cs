using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Demo03_ReactIntegration.ViewModels;

namespace Demo03_ReactIntegration.Services;

public class OpenMeteoWeatherService
{
    private readonly HttpClient httpClient;

    public OpenMeteoWeatherService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<GeocodeResult> GeocodeCity(string city)
    {
        var url = $"https://geocoding-api.open-meteo.com/v1/search?name={WebUtility.UrlEncode(city)}";
        var cities = await httpClient.GetFromJsonAsync<GeocodeResults>(url);
        return cities?.Results?.FirstOrDefault();
    }

    public async Task<List<WeatherData>> GetWeather(GeocodeResult city)
    {
        var url = $"https://api.open-meteo.com/v1/forecast?latitude={city.Latitude.ToString("0.0000", CultureInfo.InvariantCulture)}&longitude={city.Longitude.ToString("0.0000", CultureInfo.InvariantCulture)}&daily=temperature_2m_max,temperature_2m_min&timezone=auto";
        var forecast = await httpClient.GetFromJsonAsync<ForecastResults>(url);
        return forecast?.Daily?.Time
            .Select((value, index) => new WeatherData()
            {
                Date = value,
                MinTemperature = forecast.Daily.Temperature_2m_min[index],
                MaxTemperature = forecast.Daily.Temperature_2m_max[index]
            })
            .ToList();
    }

}

public class ForecastResults
{
    public ForecastDaily Daily { get; set; }
}

public class ForecastDaily
{
    public List<DateTime> Time { get; set; }
    public List<double> Temperature_2m_max { get; set; }
    public List<double> Temperature_2m_min { get; set; }
}

public class GeocodeResults
{
    public List<GeocodeResult> Results { get; set; }
}

public class GeocodeResult
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Elevation { get; set; }
}