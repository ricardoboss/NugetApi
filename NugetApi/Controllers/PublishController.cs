using Microsoft.AspNetCore.Mvc;

namespace NugetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PublishController(ILogger<PublishController> logger) : ControllerBase
{
    [HttpPut]
    public IActionResult Put(IFormFile package)
    {
        logger.LogInformation("Put: {@Package}", package.FileName);

        return Created();
    }
}
