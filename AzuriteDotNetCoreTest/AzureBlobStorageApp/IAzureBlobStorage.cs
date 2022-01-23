namespace AzureBlobStorageApp
{
public interface IAzureBlobStorage
{
    public Task<string> ReadTextFile(string filename);
    public Task CreateTextFile(string filename, byte[] data);
    public Task DeleteTextFile(string filename);
    public int NumberOfBlobs();
}

}
