using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace NugetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AutocompleteController(ILogger<AutocompleteController> logger) : ControllerBase
{
    public AutocompleteResult Get([FromQuery] string? q = null, [FromQuery] bool prerelease = false, [FromQuery] string? semVerLevel = null)
    {
        logger.LogInformation("Autocomplete query: {Query}, Prerelease: {Prerelease}, SemVerLevel: {SemVerLevel}", q, prerelease, semVerLevel);

        return new(1, ["TRENZ.EL.ElApi"]);
    }
}

public record AutocompleteResult(
    [property: JsonPropertyName("totalHits")] int TotalHits,
    [property: JsonPropertyName("data")] IEnumerable<string> Data
);
