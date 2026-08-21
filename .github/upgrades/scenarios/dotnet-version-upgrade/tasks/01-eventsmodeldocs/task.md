# 01-eventsmodeldocs: Upgrade EventsModelDocs to net10.0

Upgrade `src/EventsModelDocs/EventsModelDocs.csproj` from `net9.0` to `net10.0`. The project is already SDK-style with 0 NuGet package dependencies and 0 API incompatibilities reported in the assessment. One deprecated-package issue (NuGet.0005) was flagged; investigate and resolve it as part of this task if it applies to this project.

**Done when**: The project's `TargetFramework` is `net10.0`, the solution builds with 0 errors and 0 warnings, and the deprecated package issue is resolved or confirmed not applicable.

## Research Notes
- Project only reference: `docfx.console` v2.59.4 (0 project-to-project deps/dependants).
- `get_supported_package_version` confirms 2.59.4 is still the current supported version for net10.0 — no newer version exists, so the NuGet.0005 (deprecated package) issue is confirmed not actionable; docfx.console has no actively maintained replacement version.
- Changed `<TargetFramework>` from `net9.0` to `net10.0` in `EventsModelDocs.csproj`.
