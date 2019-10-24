using System.Threading;
using System.Threading.Tasks;
using DevNullService.Contracts;
using DevNullService.Swagger;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DevNullService.V1.Controllers
{
    public class DevNullController : Controller
    {
        static SemaphoreSlim devnullSemaphore = new SemaphoreSlim(1, 1);

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
            // Unfortunately, opening /dev/null for writing locks it to a single thread.
            // This is ugly, but at least we won't have this problem.
            await devnullSemaphore.WaitAsync();
            try
            {
                using var devnull = System.IO.File.OpenWrite("/dev/null");
                await this.Request.BodyReader.CopyToAsync(devnull);
            }
            finally
            {
                devnullSemaphore.Release();
            }

            return Ok();
        }

        /// <summary>
        /// Get a lot of NULs
        /// </summary>
        /// <remarks>
        /// `GET` from this endpoing to read from `/dev/zero`.
        /// </remarks>
        [HttpGet(ApiRoutes.Gets.GetNulls)]
        [ProducesResponseType(200)]
        [SwaggerOperation(OperationId = "GetNulls", Tags = new[] { Tags.GetNulls })]
        public async Task<IActionResult> GetNulls([FromQuery] int length = Constants.DefaultNullsLength)
        {
            if (length < 0)
            {
                return BadRequest();
            }

            var stream = System.IO.File.OpenRead("/dev/zero");
            var buffer = new byte[length];
            var zeroCount = await stream.ReadAsync(buffer, 0, length);

            return File(buffer, "application/octet-stream");
        }
    }
}