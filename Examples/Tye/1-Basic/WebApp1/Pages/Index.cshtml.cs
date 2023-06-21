using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;
using weather;
using WebApp1.Service;

namespace WebApp1.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ForecastClient _forecatClient;
    public IndexModel(ILogger<IndexModel> logger, ForecastClient client)
    {
        _logger = logger;
        _forecatClient = client;
    }

    public string Forecast
    {
        get
        {
            var response = _forecatClient.Client.GetAsync("/weatherforecast").Result;

            var forecast = JsonSerializer.DeserializeAsync<WeatherForecast[]>
                (response.Content.ReadAsStreamAsync().Result,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }).Result;

            var sb = new StringBuilder();

            foreach (var item in forecast)
            {
                sb.Append(string.Format("{0}: {1}", item.Date.ToString(), item.TemperatureC));
            }

            return sb.ToString();
        }
    }

    public void OnGet()
    {

    }
}
