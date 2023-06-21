
namespace webapp1
{
    using System.Net.Http;

    public class ForecastClient
    {
        public HttpClient Client;

        public ForecastClient(HttpClient client)
        {
            this.Client = client;
        }
    }
}
