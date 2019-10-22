using System.Threading.Tasks;
using DevNullService.Contracts;
using DevNullService.Swagger;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DevNullService.V1.Controllers
{
    public class DevNullController : Controller
    {
        /// <summary>
        /// Copies your data to /dev/null
        /// </summary>
        /// <remarks>
        /// `POST` data to this endpoint to synchronously copy it to the server's `/dev/null`.
        /// </remarks>
        [HttpPost(ApiRoutes.Posts.PostData)]
        [ProducesResponseType(200)]
        [SwaggerOperation(OperationId = "PostData", Tags = new[] { Tags.PostData })]
        public async Task<IActionResult> PostData()
        {
            using var devnull = System.IO.File.Create("/dev/null");
            await this.Request.BodyReader.CopyToAsync(devnull);
            return Ok();
        }

        [HttpGet(ApiRoutes.Gets.GetNulls)]
        [ProducesResponseType(200)]
        [SwaggerOperation(OperationId = "GetNulls", Tags = new[] { Tags.GetNulls })]
        public async Task<IActionResult> GetNulls([FromQuery] int length = 1024)
        {
            var stream = System.IO.File.OpenRead("/dev/zero");
            var buffer = new byte[length];
            var zeroCount = await stream.ReadAsync(buffer, 0, length);

            return File(buffer, "application/octet-stream");
        }
    }
}