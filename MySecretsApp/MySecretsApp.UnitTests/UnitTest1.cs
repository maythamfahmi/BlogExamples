using System;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;

namespace MySecretsApp.UnitTests
{
    public class Tests
    {
        private readonly IConfiguration _config;

        public Tests()
        {
            _config = new ConfigurationBuilder()
                .AddUserSecrets<Tests>()
                .Build();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string apiKey = _config["apikey"];

            Console.WriteLine(apiKey);
        }
    }
}