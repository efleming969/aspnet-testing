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
            var requestObject = new {Name = "123456"};
            var response = client.PostAsync("simple",
                new StringContent(JsonConvert.SerializeObject(requestObject), Encoding.UTF8, "application/json"));

            var result = response.Result;

            Assert.False(result.IsSuccessStatusCode);
            var content = result.Content.ReadAsStringAsync().Result;

            Assert.NotNull(content);
        }
    }
}
