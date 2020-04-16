using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace api.test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var webHostBuilder =
                new WebHostBuilder()
                    .UseEnvironment("Development")
                    .UseStartup<Startup>();

            var server = new TestServer(webHostBuilder);
            var client = server.CreateClient();
            var stringContent = new StringContent(JsonConvert.SerializeObject(new {Name = "123456"}), Encoding.UTF8,
                "application/json");

            var response = client.PostAsync("simple", stringContent);
            var result = response.Result;
            var content = result.Content.ReadAsStringAsync().Result;

            Assert.False(result.IsSuccessStatusCode);
            Assert.Equal(@"{""Name"":[""much too long""]}", content);
        }
    }
}