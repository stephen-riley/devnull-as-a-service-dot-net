using System.Threading.Tasks;
using DevNullService.Swagger;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DevNullService.Controllers
{
    public class DevNullController : Controller
    {
        /// <summary>
        /// Copies your data to /dev/null
        /// </summary>
        /// <remarks>
        /// `POST` data to this endpoint to synchronously copy it to the server's `/dev/null`.
        /// </remarks>
        [HttpPost("/api")]
        [ProducesResponseType(200)]
        [SwaggerOperation(OperationId = "PostData", Tags = new[] { Tags.PostData })]
        public async Task<IActionResult> PostData()
        {
            using var devnull = System.IO.File.Create("/dev/null");
            await this.Request.BodyReader.CopyToAsync(devnull);
            return Ok();
        }
    }
}