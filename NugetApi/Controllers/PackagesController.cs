using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace NugetApi.Controllers;

[ApiController]
[Route("[controller]/{id}")]
public class PackagesController(ILogger<PackagesController> logger) : ControllerBase
{
    [HttpGet("index.json")]
    public PackagesIndexResult Index(string id)
    {
        logger.LogInformation("Package index: {Id}", id);

        // if (id == "trenz.el.elapi")
            return new(["1.0.0", "8.0.0", "15.0.0"]);

        Response.StatusCode = StatusCodes.Status404NotFound;
        return new(Array.Empty<string>());
    }

    [HttpGet("{version}/{filename}")]
    public IActionResult Get(string id, string version, string filename)
    {
        logger.LogInformation("Package: {Id} {Version} {Filename}", id, version, filename);

        return File(Array.Empty<byte>(), "application/octet-stream", filename);
    }
}

public record PackagesIndexResult([property: JsonPropertyName("versions")] IEnumerable<string> Versions);
