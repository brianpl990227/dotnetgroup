using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using User.API;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using User.Domain.Login;
using System.Net;

namespace User.IntegrationTest.Controllers.Auth
{
    public class LoginTest 
    {
        private readonly TestServer server;
        private readonly HttpClient client;

        public LoginTest()
        {
            server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            client = server.CreateClient();
        }

        [Fact]
        public async void Login_Ok_Test()
        {
            var model = new { Email = "brianpl990227@gmail.com", Password = "1234567890" };

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //Act
            var response = await client.PostAsync("auth", httpContent);

            //Assert
            response.EnsureSuccessStatusCode();
            var x = await response.Content.ReadAsAsync<LoginResultMO>();
            Assert.IsType<LoginResultMO>(x);
         
           
               
        }

        [Fact]
        public async void Login_Fail_Test()
        {
            var model = new { Email = "brianpl990227@gmail.com", Password = "12345678900" };

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //Act
            var response = await client.PostAsync("auth", httpContent);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async void Login_Unauthorized_Test()
        {
            var model = new { Email = "BlockedUser@gmail.com", Password = "1234567890" };

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //Act
            var response = await client.PostAsync("auth", httpContent);

            //Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }


    }
}
