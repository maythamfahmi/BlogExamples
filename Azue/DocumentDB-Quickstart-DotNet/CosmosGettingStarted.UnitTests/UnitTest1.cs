using CosmosGettingStartedTutorial;
using Microsoft.Azure.Cosmos;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DocumentDB_Quickstart_DotNet.UnitTests
{
    public class UnitTest1
    {
        private static readonly string EndpointUri = ConfigurationManager.AppSettings["EndPointUri"];
        private static readonly string PrimaryKey = ConfigurationManager.AppSettings["PrimaryKey"];
        private CosmosClient cosmosClient;
        private Database database;
        private Container container;
        private string databaseId = "db";
        private string containerId = "items";

        [Fact]
        public async Task Test1()
        {
            CosmosClientOptions cosmosClientOptions = new CosmosClientOptions()
            {
                ApplicationName = "CosmosDBDotnetQuickstart",
                ConnectionMode = ConnectionMode.Gateway,
                HttpClientFactory = () =>
                {
                    HttpMessageHandler httpMessageHandler = new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    };

                    return new HttpClient(httpMessageHandler);
                },
            };
            
            this.cosmosClient = new CosmosClient(EndpointUri, PrimaryKey, cosmosClientOptions);

            var p = new Program();

            await p.CreateDatabaseAsync();

        }
    }
}