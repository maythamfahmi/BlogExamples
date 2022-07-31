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
                .AddUserSecrets<Tests>(true)
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
           
            // the test can consume this api key for usage :)
        }
    }
}