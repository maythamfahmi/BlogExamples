using Moq;
using System.Text;
using Xunit;

namespace AzureBlobStorageApp.UnitTests;

public class AzureBlobStorageMockUnitTests
{
    private const string Content = "Some Data inside file Content";

    [Fact]
    public async Task AzureBlobStorageTest()
    {
        // Arrange
        var mock = new Mock<IAzureBlobStorage>();

        mock
            .Setup(azureBlobStorage => azureBlobStorage.CreateTextFile(It.IsAny<string>(), It.IsAny<byte[]>()))
            .Callback(() =>
            {
                mock.Setup(azureBlobStorage => azureBlobStorage.ReadTextFile(It.IsAny<string>()))
                    .Returns(async () => await Task.FromResult(Content));
                mock.Setup(azureBlobStorage => azureBlobStorage.NumberOfBlobs())
                    .Returns(1);
            });

        mock
            .Setup(azureBlobStorage => azureBlobStorage.DeleteTextFile(It.IsAny<string>()))
            .Callback(() =>
            {
                mock.Setup(azureBlobStorage => azureBlobStorage.ReadTextFile(It.IsAny<string>()))
                    .Returns(async () => await Task.FromResult(string.Empty));
                mock.Setup(azureBlobStorage => azureBlobStorage.NumberOfBlobs())
                    .Returns(0);
            });

        // Act
        await mock.Object.CreateTextFile("file.txt", Encoding.UTF8.GetBytes(Content));
        var readTextFile = await mock.Object.ReadTextFile("file.txt");
        var filesCount = mock.Object.NumberOfBlobs();

        // Assert
        Assert.Equal(Content, readTextFile);
        Assert.Equal(1, filesCount);

        // Finalizing Act
        await mock.Object.DeleteTextFile("file.txt");
        var readTextFileAfterDelete = await mock.Object.ReadTextFile("file.txt");
        var filesCountAfterDelete = mock.Object.NumberOfBlobs();

        // Finalizing Assert
        Assert.Equal(string.Empty, readTextFileAfterDelete);
        Assert.Equal(0, filesCountAfterDelete);
    }

}
