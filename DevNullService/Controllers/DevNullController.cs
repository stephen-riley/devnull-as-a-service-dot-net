using System;
using System.IO.Pipelines;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DevNullService.Controllers {
    public class DevNullController : Controller {

        [HttpPost("/api")]
        public async Task<IActionResult> PostData() {
            using var devnull = System.IO.File.Create("/dev/null");
            await this.Request.BodyReader.CopyToAsync(devnull);
            return Ok();
        }
    }
}