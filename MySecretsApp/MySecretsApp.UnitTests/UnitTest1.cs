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

            Assert.AreEqual("de7fb477-2cce-4888-a63a-7196f55e3568", apiKey);
        }
    }
}