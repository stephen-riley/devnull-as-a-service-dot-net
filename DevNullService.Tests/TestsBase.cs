using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DevNullService.Contracts;
using Microsoft.AspNetCore.Mvc.Testing;

namespace DevNullService.Tests
{
    public class TestsBase
    {
        protected readonly HttpClient TestClient;

        protected TestsBase()
        {
            var appFactory = new WebApplicationFactory<Startup>()
            .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        Console.WriteLine("here");
                    });
                });

            TestClient = appFactory.CreateClient();
        }

        protected async Task<(HttpStatusCode, byte[])> ExecuteGetAsync(int? length = null)
        {
            var url = length == null
                    ? ApiRoutes.Gets.GetNulls
                    : $"{ApiRoutes.Gets.GetNulls}?length={length}";

            var response = await TestClient.GetAsync(url);
            var content = await response.Content.ReadAsByteArrayAsync();
            return (response.StatusCode, content);
        }

        protected async Task<(HttpStatusCode, byte[])> ExecutePostWithStringAsync(string request)
        {
            request ??= string.Empty;
            var buffer = Encoding.UTF8.GetBytes(request);
            return await ExecutePostWithBinaryAsync(buffer);
        }

        protected async Task<(HttpStatusCode, byte[])> ExecutePostWithBinaryAsync(byte[] request)
        {
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Posts.PostData, request);
            var content = await response.Content.ReadAsByteArrayAsync();
            return (response.StatusCode, content);
        }
    }
}