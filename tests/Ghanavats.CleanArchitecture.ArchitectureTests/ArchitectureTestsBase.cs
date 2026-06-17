using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using Ghanavats.CleanArchitecture.Core.Entities;
using Ghanavats.CleanArchitecture.Infrastructure.DependencyInjection;
using Ghanavats.CleanArchitecture.Shared;
using Ghanavats.CleanArchitecture.UseCases.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Ghanavats.CleanArchitecture.ArchitectureTests;

public class ArchitectureTestsBase
{
    private protected static readonly System.Reflection.Assembly PresentationAssembly = typeof(Program).Assembly;

    private protected static readonly System.Reflection.Assembly InfrastructureAssembly =
        typeof(InfrastructureExtension).Assembly;

    private protected static readonly System.Reflection.Assembly DomainAssembly = typeof(Person).Assembly;

    private protected static readonly System.Reflection.Assembly ApplicationAssembly =
        typeof(RegisterApplicationServices).Assembly;

    private protected static readonly System.Reflection.Assembly SharedAssembly = typeof(AssemblyMarker).Assembly;

    private protected readonly Architecture Architecture = new ArchLoader()
        .LoadAssemblies(
            PresentationAssembly,
            InfrastructureAssembly,
            DomainAssembly,
            ApplicationAssembly,
            SharedAssembly
        )
        .Build();
}
