using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Demo03_ReactIntegration.Services;
using DotVVM.Framework.ViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo03_ReactIntegration.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        private readonly OpenMeteoWeatherService weatherService;

        public List<WeatherData> WeatherForecast { get; set; }

        public string City { get; set; } = "Prague";

        public string SelectedSerie { get; set; }

        public string ErrorMessage { get; set; }


        public DefaultViewModel(OpenMeteoWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        public async Task GetWeather()
        {
            ErrorMessage = "";
            WeatherForecast = null;

            var city = await weatherService.GeocodeCity(City);
            if (city == null)
            {
                ErrorMessage = $"Couldn't find city '{City}'!";
                return;
            }

            var forecast = await weatherService.GetWeather(city);
            if (forecast == null)
            {
                ErrorMessage = "Couldn't get weather forecast!";
                return;
            }

            WeatherForecast = forecast;
        }
    }

    public class WeatherData
    {
        public DateTime Date { get; set; }
        public string DateDisplayText => Date.ToString("d MMM", CultureInfo.InvariantCulture);
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
    }
}
