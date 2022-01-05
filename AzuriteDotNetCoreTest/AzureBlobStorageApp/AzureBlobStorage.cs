using Azure.Storage.Blobs;

namespace AzureBlobStorageApp;

public class AzureBlobStorage
{

    private readonly BlobContainerClient _blobContainerClient;

    public AzureBlobStorage(string connectionString, string container)
    {
        _blobContainerClient = new BlobContainerClient(connectionString, container);
        _blobContainerClient.CreateIfNotExists();
    }

    public async Task<string> ReadTextFile(string filename)
    {
        var blob = _blobContainerClient.GetBlobClient(filename);
        if (!await _blobContainerClient.ExistsAsync()) return string.Empty;
        var reading = await blob.DownloadStreamingAsync();
        StreamReader reader = new StreamReader(reading.Value.Content);
        return await reader.ReadToEndAsync();
    }

    public async Task CreateTextFile(string filename, byte[] data)
    {
        var blob = _blobContainerClient.GetBlobClient(filename);
        await using var ms = new MemoryStream(data, false);
        await blob.UploadAsync(ms, CancellationToken.None);
    }

    public async Task DeleteTextFile(string filename)
    {
        var blobClient = _blobContainerClient.GetBlobClient(filename);
        await blobClient.DeleteAsync();
    }

}
