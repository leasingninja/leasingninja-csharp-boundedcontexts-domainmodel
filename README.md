# leasingninja-csharp-boundedcontexts-domainmodel

The LeasingNinja in C# with DDD style bounded contexts and domain model.

## Update Dependencies

```bash
$ dotnet add src
/LeasingNinja.Sales/LeasingNinja.Sales.csproj package NMolecules.DDD

$ dotnet add src
/LeasingNinja.RiskManagement/LeasingNinja.RiskManagement.csproj package NMolecules.DDD
```

For unit tests:

```bash
dotnet add tests/LeasingNinja.Riskmanagement.Test/LeasingNinja.Riskmanagement.Test.csproj package coverlet.collector
dotnet add tests/LeasingNinja.Riskmanagement.Test/LeasingNinja.Riskmanagement.Test.csproj package Microsoft.NET.Test.Sdk
dotnet add tests/LeasingNinja.Riskmanagement.Test/LeasingNinja.Riskmanagement.Test.csproj package Moq
dotnet add tests/LeasingNinja.Riskmanagement.Test/LeasingNinja.Riskmanagement.Test.csproj package NFluent
dotnet add tests/LeasingNinja.Riskmanagement.Test/LeasingNinja.Riskmanagement.Test.csproj package xunit
dotnet add tests/LeasingNinja.Riskmanagement.Test/LeasingNinja.Riskmanagement.Test.csproj package xunit.runner.visualstudio
```
