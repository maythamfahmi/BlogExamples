using System.Text;
using Xunit;

namespace AzureBlobStorageApp.UnitTests;

public class AzureBlobStorageUnitTests
{
    private const string Content = "Some Data inside file Content";

    private const string DefaultEndpointsProtocol = "http";
    private const string AccountName = "devstoreaccount1";
    private const string AccountKey = "Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==";
    private const string BlobEndpoint = "http://127.0.0.1:10000/devstoreaccount1";
    private const string ConnectionString = $"DefaultEndpointsProtocol={DefaultEndpointsProtocol};AccountName={AccountName};AccountKey={AccountKey};BlobEndpoint={BlobEndpoint};";

    private const string Container = "container-1";

    private readonly AzureBlobStorage _azureBlobStorage;


    public AzureBlobStorageUnitTests()
    {
        _azureBlobStorage = new AzureBlobStorage(ConnectionString, Container);
    }

    //https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/overview

    [Fact(Skip = "Works only on local environment")]
    public async Task AzureBlobStorageTest()
    {
        // Arrange
        await _azureBlobStorage?.CreateTextFile("file.txt", Encoding.UTF8.GetBytes(Content))!;

        // Act
        var readTextFile = await _azureBlobStorage.ReadTextFile("file.txt");

        // Assert
        Assert.Equal(Content, readTextFile);

        // Finalizing
        await _azureBlobStorage.DeleteTextFile("file.txt");
    }

}
