# .NET Upgrade Plan

### Selected Strategy
**All-At-Once** — Single project upgraded in one operation.
**Rationale**: 1 project, already on .NET 9 (SDK-style), no incompatible packages, straightforward TFM bump to net10.0.

## Tasks

### 01-eventsmodeldocs: Upgrade EventsModelDocs to net10.0

Upgrade `src/EventsModelDocs/EventsModelDocs.csproj` from `net9.0` to `net10.0`. The project is already SDK-style with 0 NuGet package dependencies and 0 API incompatibilities reported in the assessment. One deprecated-package issue (NuGet.0005) was flagged; investigate and resolve it as part of this task if it applies to this project.

**Done when**: The project's `TargetFramework` is `net10.0`, the solution builds with 0 errors and 0 warnings, and the deprecated package issue is resolved or confirmed not applicable.
