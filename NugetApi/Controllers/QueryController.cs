using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace NugetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QueryController(ILogger<QueryController> logger) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<QueryResult>(StatusCodes.Status200OK)]
    public QueryResult Get([FromQuery] string? q = null, [FromQuery] int skip = 0, [FromQuery] int take = 20, [FromQuery] bool prerelease = false, [FromQuery] string? semVerLevel = null)
    {
        logger.LogInformation("Query: {Query}, Skip: {Skip}, Take: {Take}, Prerelease: {Prerelease}, SemVerLevel: {SemVerLevel}", q, skip, take, prerelease, semVerLevel);

        return new(1, [
            new(
                "https://localhost:7156/registrations/trenz.el.elapi/index.json",
                "Package",
                "https://localhost:7156/registrations/trenz.el.elapi/index.json",
                "TRENZ.EL.ElApi",
                "1.0.0",
                "Helper library to build an easyLogic-compatible Web API.",
                "",
                "TRENZ.EL.ElApi",
                "https://www.nuget.org/packages/TRENZ.EL.ElApi/1.0.0/license",
                "https://docs.ela.easylogic.de/",
                [],
                [
                    "EL.ELAPI",
                ],
                [
                    "trenz",
                ],
                664,
                false,
                [
                    new(
                        "Dependency"
                    ),
                ],
                [
                    new(
                        "1.0.0",
                        355,
                        "https://localhost:7156/registrations/trenz.el.elapi/1.0.0.json"
                    ),
                ],
                []
            ),
        ]);
    }
}

public record QueryResult(
    [property: JsonPropertyName("totalHits")] int TotalHits,
    [property: JsonPropertyName("data")] IEnumerable<QueryResultHit> Data
);

public record QueryResultHit(
    [property: JsonPropertyName("@id")] string Id,
    [property: JsonPropertyName("@type")] string Type,
    [property: JsonPropertyName("registration")] string Registration,
    [property: JsonPropertyName("id")] string PackageId,
    [property: JsonPropertyName("version")] string Version,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("summary")] string Summary,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("licenseUrl")] string LicenseUrl,
    [property: JsonPropertyName("projectUrl")] string ProjectUrl,
    [property: JsonPropertyName("tags")] string[] Tags,
    [property: JsonPropertyName("authors")] string[] Authors,
    [property: JsonPropertyName("owners")] string[] Owners,
    [property: JsonPropertyName("totalDownloads")] int TotalDownloads,
    [property: JsonPropertyName("verified")] bool Verified,
    [property: JsonPropertyName("packageTypes")] PackageType[] PackageTypes,
    [property: JsonPropertyName("versions")] VersionInfo[] Versions,
    [property: JsonPropertyName("vulnerabilities")] string[] Vulnerabilities
);

public record PackageType([property: JsonPropertyName("name")] string Name);

public record VersionInfo(
    [property: JsonPropertyName("version")] string Version,
    [property: JsonPropertyName("downloads")] int Downloads,
    [property: JsonPropertyName("@id")] string Id
);
