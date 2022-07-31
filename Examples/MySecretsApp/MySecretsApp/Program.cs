using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();
string apiKey = config["apikey"];

Console.WriteLine(apiKey);