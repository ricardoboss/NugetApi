# Nuget clients

Different nuget clients use different services to manage packages.

## Restore

### `nuget.exe`

When running `nuget restore -Source https://localhost:7156/index.json` the following endpoints are hit:

- `https://localhost:7156/index.json`
- for each installed package:
  - `https://localhost:7156/packages/[lowercase-package-id]/index.json`
  - `https://localhost:7156/packages/[lowercase-package-id]/[package-version]/[lowercase-package-id-and-version].nupkg`

So, `nuget.exe` only uses the `PackageBaseAddress` service for restores.

### `dotnet`

Running `dotnet restore -s https://localhost:7156/index.json` the following endpoints are hit:

- for each installed package:
  - `https://localhost:7156/registrations/[lowercase-package-id]/index.json`
  - (based on the urls returned from the previous call)
  - `https://localhost:7156/packages/[lowercase-package-id]/[package-version]/[lowercase-package-id-and-version].nupkg`

So, `dotnet` only uses the `RegistrationsBaseUrl` service for restores.

## Publish

For publishing, both nuget and dotnet use the `PackagePublish` service.
