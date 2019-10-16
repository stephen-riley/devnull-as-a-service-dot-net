using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DevNullService.Controllers
{
    public class DevNullController : Controller
    {
        [HttpPost("/api")]
        [SwaggerOperation("PostData", OperationId = "PostData")]
        public async Task<IActionResult> PostData()
        {
            using var devnull = System.IO.File.Create("/dev/null");
            await this.Request.BodyReader.CopyToAsync(devnull);
            return Ok();
        }
    }
}