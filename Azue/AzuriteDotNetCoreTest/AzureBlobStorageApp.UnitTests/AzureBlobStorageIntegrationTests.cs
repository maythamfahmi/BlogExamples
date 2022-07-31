using System.Text;
using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace AzureBlobStorageApp.UnitTests;

public class AzureBlobStorageIntegrationTests : IAsyncLifetime
{
    private const string Content = "Some Data inside file Content";

    private const string DefaultEndpointsProtocol = "http";
    private const string AccountName = "devstoreaccount1";
    private const string AccountKey = "Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==";
    private const string BlobEndpoint = "http://127.0.0.1:10000/devstoreaccount1";
    private const string ConnectionString = $"DefaultEndpointsProtocol={DefaultEndpointsProtocol};AccountName={AccountName};AccountKey={AccountKey};BlobEndpoint={BlobEndpoint};";

    private const string Container = "container-1";

    private AzureBlobStorage? _azureBlobStorage;

    private readonly DockerClient _client;
    private readonly Task<ContainerResponse> _response;
    private string _id = string.Empty;

    public AzureBlobStorageIntegrationTests()
    {
        var builder = new ConfigurationBuilder()
            .AddUserSecrets<AzureBlobStorageIntegrationTests>(true);

        IConfiguration configuration = builder.Build();

        var email = configuration["DockerEmail"];
        var username = configuration["DockerUserName"];
        var password = configuration["DockerPassword"];

        _client = new DockerClientConfiguration().CreateClient();
        _response = AzuriteContainer.Start(_client, email, username, password);
    }

    [Fact]
    public async Task AzureBlobStorageTest()
    {
        // Arrange
        await _azureBlobStorage?.CreateTextFile("file.txt", Encoding.UTF8.GetBytes(Content))!;

        // Act
        var readTextFile = await _azureBlobStorage.ReadTextFile("file.txt");
        var filesCount = _azureBlobStorage.NumberOfBlobs();

        // Assert
        Assert.Equal(Content, readTextFile);
        Assert.Equal(1, filesCount);

        // Finalizing Act
        await _azureBlobStorage.DeleteTextFile("file.txt");
        var readTextFileAfterDelete = await _azureBlobStorage.ReadTextFile("file.txt");
        var filesCountAfterDelete = _azureBlobStorage.NumberOfBlobs();
        
        // Finalizing Assert
        Assert.Equal(string.Empty, readTextFileAfterDelete);
        Assert.Equal(0, filesCountAfterDelete);
    }

    /// <summary>
    /// Initial first time setup
    /// </summary>
    /// <returns></returns>
    public async Task InitializeAsync()
    {
        if (string.IsNullOrEmpty(_id))
        {
            var resp = await _response;
            _id = resp.Id;
        }

        await _client.Containers.StartContainerAsync(_id, null);

        _azureBlobStorage = new AzureBlobStorage(ConnectionString, Container);
    }

    /// <summary>
    /// Teardown
    /// </summary>
    /// <returns></returns>
    async Task IAsyncLifetime.DisposeAsync()
    {
        var stopParams = new ContainerStopParameters()
        {
            WaitBeforeKillSeconds = 3
        };
        await _client.Containers.StopContainerAsync(_id, stopParams, CancellationToken.None);

        var removeParams = new ContainerRemoveParameters()
        {
            Force = true
        };
        await _client.Containers.RemoveContainerAsync(_id, removeParams, CancellationToken.None);
        _client.Dispose();
        _response.Dispose();
    }

}
