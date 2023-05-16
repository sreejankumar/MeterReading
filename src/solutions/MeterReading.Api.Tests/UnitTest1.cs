using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace MeterReading.Api.Tests
{
    public class Tests
    {

        private const string RequestUrl = "/api/MeterReading";
        private HttpClient _client;

        [OneTimeSetUp]
        public void Setup()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());

            _client = server.CreateClient();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}