using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApp1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ForecastClient _forecastClient;

        public IndexModel(ILogger<IndexModel> logger, ForecastClient forecastClient)
        {
            _logger = logger;
            _forecastClient = forecastClient;
        }

        public string Forecast
        {
            get
            {
                var response = _forecastClient.Client.GetAsync("/weatherforecast").Result;

                var forecast = JsonSerializer.DeserializeAsync<WeatherForecast[]>(response.Content.ReadAsStreamAsync().Result, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                }).Result;

                var forecastData = new StringBuilder();

                foreach (var forecastItem in forecast)
                {
                    forecastData.Append(string.Format("{0}: {1}, {2}", forecastItem.Date.ToString(), forecastItem.TemperatureC, forecastItem.Summary));
                }

                return forecastData.ToString();
            }
        }

        public void OnGet()
        {

        }
    }
}
