using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace NugetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistrationsController(ILogger<RegistrationsController> logger) : ControllerBase
{
    [HttpGet("{id}/index.json")]
    public PackageRegistration? Index(string id)
    {
        logger.LogInformation("Registration index: {Id}", id);

        return new(
            "https://localhost:7156/registrations/trenz.el.elapi/index.json",
            [
                "PackageRegistration",
                "catalog:CatalogRoot",
            ],
            DateTimeOffset.UtcNow,
            "commitId",
            1,
            [
                new(
                    "https://localhost:7156/registrations/trenz.el.elapi/index.json#page/1.0.0-beta1/1.0.0",
                    "catalog:CatalogPage",
                    DateTimeOffset.UtcNow,
                    "commitId",
                    1,
                    new[]
                    {
                        new CatalogPackage(
                            "https://localhost:7156/registrations/trenz.el.elapi/1.0.0-beta1.json",
                            "Package",
                            DateTimeOffset.UtcNow,
                            "commitId",
                            "https://localhost:7156/packages/trenz.el.elapi/1.0.0-beta1/trenz.el.elapi.1.0.0-beta1.nupkg",
                            "https://localhost:7156/registrations/trenz.el.elapi/index.json",
                            new(
                                "https://localhost:7156/catalog/0/data/2022.10.05.13.19.36/trenz.el.elapi.1.0.0-beta1.json",
                                "PackageDetails",
                                "El.ElApi",
                                [
                                    new(
                                        "https://localhost:7156/catalog/0/data/2022.10.05.13.19.36/trenz.el.elapi.1.0.0-beta1.json#dependencygroup/.netcoreapp3.1",
                                        "PackageDependencyGroup",
                                        ".NETCoreApp3.1"
                                    ),
                                    new(
                                        "https://localhost:7156/catalog/0/data/2022.10.05.13.19.36/trenz.el.elapi.1.0.0-beta1.json#dependencygroup/net6.0",
                                        "PackageDependencyGroup",
                                        "net6.0"
                                    ),
                                ],
                                "Helper library to build an easyLogic-compatible Web API.",
                                "",
                                "TRENZ.EL.ElApi",
                                "C#",
                                "",
                                "https://docs.ela.easylogic.de/",
                                "",
                                true,
                                "1.0.0",
                                "https://localhost:7156/packages/trenz.el.elapi/1.0.0-beta1/trenz.el.elapi.1.0.0-beta1.nupkg",
                                "https://docs.ela.easylogic.de/",
                                DateTimeOffset.UtcNow,
                                false,
                                "",
                                "EL.ELAPI",
                                "TRENZ.EL.ElApi",
                                "14.0.0"
                            )
                        ),
                    },
                    "https://localhost:7156/registrations/trenz.el.elapi/index.json",
                    "14.0.0-beta1",
                    "14.0.0"
                ),
            ]
        );
    }
}

public record PackageRegistration(
    [property: JsonPropertyName("@id")] string Id,
    [property: JsonPropertyName("@type")] List<string> Type,
    [property: JsonPropertyName("commitTimeStamp")] DateTimeOffset CommitTimeStamp,
    [property: JsonPropertyName("commitId")] string CommitId,
    [property: JsonPropertyName("count")] int Count,
    [property: JsonPropertyName("items")] IEnumerable<CatalogPage> Items
);

public record CatalogPage(
    [property: JsonPropertyName("@id")] string Id,
    [property: JsonPropertyName("@type")] string Type,
    [property: JsonPropertyName("commitTimeStamp")] DateTimeOffset CommitTimeStamp,
    [property: JsonPropertyName("commitId")] string CommitId,
    [property: JsonPropertyName("count")] int Count,
    [property: JsonPropertyName("items")] IEnumerable<CatalogPackage> Items,
    [property: JsonPropertyName("parent")] string Parent,
    [property: JsonPropertyName("lower")] string Lower,
    [property: JsonPropertyName("upper")] string Upper
);

public record CatalogPackage(
    [property: JsonPropertyName("@id")] string Id,
    [property: JsonPropertyName("@type")] string Type,
    [property: JsonPropertyName("commitTimeStamp")] DateTimeOffset CommitTimeStamp,
    [property: JsonPropertyName("commitId")] string CommitId,
    [property: JsonPropertyName("packageContent")] string PackageContent,
    [property: JsonPropertyName("registration")] string Registration,
    [property: JsonPropertyName("catalogEntry")] CatalogEntry CatalogEntry
);

public record CatalogEntry(
    [property: JsonPropertyName("@id")] string Id,
    [property: JsonPropertyName("@type")] string Type,
    [property: JsonPropertyName("authors")] string Authors,
    [property: JsonPropertyName("dependencyGroups")] IEnumerable<DependencyGroup> DependencyGroups,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("iconUrl")] string IconUrl,
    [property: JsonPropertyName("id")] string PackageId,
    [property: JsonPropertyName("language")] string Language,
    [property: JsonPropertyName("licenseExpression")] string LicenseExpression,
    [property: JsonPropertyName("licenseUrl")] string LicenseUrl,
    [property: JsonPropertyName("readmeUrl")] string ReadmeUrl,
    [property: JsonPropertyName("listed")] bool Listed,
    [property: JsonPropertyName("minClientVersion")] string MinClientVersion,
    [property: JsonPropertyName("packageContent")] string PackageContent,
    [property: JsonPropertyName("projectUrl")] string ProjectUrl,
    [property: JsonPropertyName("published")] DateTimeOffset Published,
    [property: JsonPropertyName("requireLicenseAcceptance")] bool RequireLicenseAcceptance,
    [property: JsonPropertyName("summary")] string Summary,
    [property: JsonPropertyName("tags")] string Tags,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("version")] string Version
);

public record DependencyGroup(
    [property: JsonPropertyName("@id")] string Id,
    [property: JsonPropertyName("@type")] string Type,
    [property: JsonPropertyName("targetFramework")] string TargetFramework
);
