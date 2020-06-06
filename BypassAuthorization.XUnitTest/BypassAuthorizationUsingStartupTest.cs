using System.Net.Http;
using System.Threading.Tasks;
using BypassAuthorization.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace BypassAuthorization.XUnitTest
{
    public class BypassAuthorizationUsingStartupTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public BypassAuthorizationUsingStartupTest(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task AuthorizedByPassed()
        {
            var response = (await _client.GetAsync("/weatherforecast")).EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<WeatherForecast[]>(stringResponse);

            Assert.Equal(5, result.Length);
        }
    }

}
