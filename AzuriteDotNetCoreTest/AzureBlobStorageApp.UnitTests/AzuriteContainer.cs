using System.Net.Sockets;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace AzureBlobStorageApp.UnitTests
{
    public class AzuriteContainer
    {
        private const string AzuriteImg = "mcr.microsoft.com/azure-storage/azurite";
        private const string AzuritePrefix = "azurite";

        public static async Task<CreateContainerResponse> Start(DockerClient client, string? email = null, string? username = null, string? password = null)
        {
            await client.Images.CreateImageAsync(
                new ImagesCreateParameters
                {
                    FromImage = AzuriteImg,
                    Tag = "latest",
                },
                new AuthConfig
                {
                    Email = email,
                    Username = username,
                    Password = password
                },
                new Progress<JSONMessage>());

            var response = await client.Containers.CreateContainerAsync(new CreateContainerParameters()
            {
                Image = AzuriteImg,
                Name = $"{AzuritePrefix}-{Guid.NewGuid()}",

                ExposedPorts = new Dictionary<string, EmptyStruct>
                {
                    {"10000", default(EmptyStruct)}
                },
                HostConfig = new HostConfig
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                        {"10000", new List<PortBinding> {new PortBinding {HostPort = "10000"}}}
                    },
                    PublishAllPorts = true
                }
            });


            return response;
        }

    }
}
