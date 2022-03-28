using Microsoft.AspNetCore.Mvc;

namespace UploadFileApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RobotController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file,[FromServices] IWebHostEnvironment env)
        {
            var filePath = Path.Combine(env.ContentRootPath, "Files", file.FileName);
            using var stream = System.IO.File.Create(filePath);
            stream.Position = 0;
            await file.CopyToAsync(stream);

            return Ok();
        }
    }
}
