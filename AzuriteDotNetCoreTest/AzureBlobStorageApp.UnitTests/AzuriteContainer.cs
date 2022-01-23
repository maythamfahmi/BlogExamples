using Docker.DotNet;
using Docker.DotNet.Models;

namespace AzureBlobStorageApp.UnitTests
{
    public class AzuriteContainer
    {
        private const string AzuriteImg = "mcr.microsoft.com/azure-storage/azurite";
        private const string AzuritePrefix = "azurite";

        public static async Task<ContainerResponse> Start(DockerClient client, string? email = null, string? username = null, string? password = null)
        {
            ContainerResponse containerResponse = new ContainerResponse();

            var containers = await client.Containers.ListContainersAsync(
                new ContainersListParameters()
                {
                    All = true
                }
            );

            var azuriteContainers = containers.Where(e => e.Names.Any(n => n.Contains("azurite"))).ToList();

            foreach (var item in azuriteContainers)
            {
                var state = item.State;
                if (state == "running") continue;
                await client.Containers.StopContainerAsync(item.ID, new ContainerStopParameters(),
                    CancellationToken.None);
                await client.Containers.RemoveContainerAsync(item.ID, new ContainerRemoveParameters());
            }

            if (azuriteContainers.Any(e => e.State != "running") || azuriteContainers.Count == 0)
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

                    //enforce change public ip
                    ExposedPorts = new Dictionary<string, EmptyStruct>
                    {
                        {"10000", default(EmptyStruct)}
                    },
                    //host private port that init random public port. starting port, could be more service with other ports
                    HostConfig = new HostConfig
                    {
                        PortBindings = new Dictionary<string, IList<PortBinding>>
                        {
                            {"10000", new List<PortBinding> {new PortBinding {HostPort = "10000"}}}
                        },
                        PublishAllPorts = true
                    }
                });

                containerResponse.Id = response.ID;
                containerResponse.Warnings = response.Warnings;
            }
            else
            {
                var responses = azuriteContainers.FirstOrDefault(e => e.State == "running");
                if (responses == null) return containerResponse;
                containerResponse.Id = responses.ID;
            }

            return containerResponse;
        }

    }
}
