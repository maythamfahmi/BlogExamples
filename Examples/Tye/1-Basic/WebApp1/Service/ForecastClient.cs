namespace WebApp1.Service
{
    public class ForecastClient
    {
        public HttpClient Client;

        public ForecastClient(HttpClient client)
        {
            this.Client = client;
        }
    }
}
