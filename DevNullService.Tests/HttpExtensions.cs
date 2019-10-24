using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DevNullService.Tests
{
    public static class HttpExtensions
    {
        public static void Deconstruct(this HttpResponseMessage httpResponse, HttpStatusCode statusCode, HttpContent content)
        {
            statusCode = httpResponse.StatusCode;
            content = httpResponse.Content;
        }

        public static async Task<byte[]> ReadAsByteArrayAsync(this HttpContent content)
        {
            using var memStream = new MemoryStream();
            await (await content.ReadAsStreamAsync()).CopyToAsync(memStream);
            return memStream.ToArray();
        }
    }
}