using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnitV3;
using Ghanavats.CleanArchitecture.Core.Entities;
using Ghanavats.CleanArchitecture.Infrastructure.DependencyInjection;
using Ghanavats.CleanArchitecture.Shared;
using Ghanavats.CleanArchitecture.UseCases.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Ghanavats.CleanArchitecture.ArchitectureTests;

public class ArchitectureTests
{
    private static readonly System.Reflection.Assembly PresentationAssembly = typeof(Program).Assembly;
    private static readonly System.Reflection.Assembly InfrastructureAssembly = typeof(InfrastructureExtension).Assembly;
    private static readonly System.Reflection.Assembly DomainAssembly = typeof(Person).Assembly;
    private static readonly System.Reflection.Assembly ApplicationAssembly = typeof(RegisterApplicationServices).Assembly;
    private static readonly System.Reflection.Assembly SharedAssembly = typeof(AssemblyMarker).Assembly;
    
    private readonly Architecture Architecture = new ArchLoader()
        .LoadAssemblies(
            PresentationAssembly,
            InfrastructureAssembly,
            DomainAssembly,
            ApplicationAssembly,
            SharedAssembly
        )
        .Build();

    private readonly IObjectProvider<IType> DomainLayer = Types()
        .That()
        .ResideInAssembly(DomainAssembly)
        .As("Domain Layer");
    
    private readonly IObjectProvider<IType> PresentationLayer = Types()
        .That()
        .ResideInAssembly(PresentationAssembly)
        .As("Presentation Layer");

    private readonly IObjectProvider<IType> InfrastructureLayer = Types()
        .That()
        .ResideInAssembly(InfrastructureAssembly)
        .As("Infrastructure Layer");
    
    private readonly IObjectProvider<IType> ApplicationLayer = Types()
        .That()
        .ResideInAssembly(ApplicationAssembly)
        .As("Application Layer");

    private readonly IObjectProvider<IType> SharedProject = Types()
        .That()
        .ResideInAssembly(SharedAssembly)
        .As("Shared Project");
    
    private readonly IObjectProvider<IType> ApiEndpoints = Classes()
        .That().AreSealed().And().AreAbstract()
        .And().ArePublic().And().ResideInAssembly(PresentationAssembly)
        .And().HaveNameEndingWith("Endpoint")
        .As("API Endpoints");
    
    private readonly IObjectProvider<Interface> RepositoryInterfaces = Interfaces()
        .That().ResideInAssembly(ApplicationAssembly)
        .And().ArePublic()
        .And().HaveNameEndingWith("Repository")
        .As("Infrastructure Repositories");
    
    [Fact]
    public void Types_In_Presentation_ShouldNotDependRepositories()
    {
        Types().That().Are(PresentationLayer)
            .Should().NotDependOnAny(InfrastructureLayer)
            .Because("Presentation layer should not depend on Infrastructure layer")
            .Check(Architecture);
    }
        
    [Fact]
    public void Endpoints_ShouldNotDependOnRepositories()
    {
        Classes().That().Are(ApiEndpoints)
            .Should().NotDependOnAny(RepositoryInterfaces)
            .Because("API endpoints should not directly depend on Repository interfaces")
            .Check(Architecture);
    }
    
    [Fact]
    public void RepositoryInterfaces_ShouldBeImplementedInInfrastructureLayer()
    {
        Classes().That().Are(InfrastructureLayer)
            .And().ResideInNamespace("Ghanavats.CleanArchitecture.Infrastructure.Repositories")
            .And().AreInternal().And().AreSealed()
            .Should().ImplementAnyInterfaces(RepositoryInterfaces)
            .Because("Repository interfaces should be implemented in the Infrastructure layer")
            .Check(Architecture);
    }
    
    [Fact]
    public void RepositoryInterfaces_ShouldNotBeImplementedInAnyLayerButInfrastructure()
    {
        Classes().That().AreNot(InfrastructureLayer)
            .And().DoNotResideInNamespace("Ghanavats.CleanArchitecture.Infrastructure.Repositories")
            .Should().NotImplementAnyInterfaces(RepositoryInterfaces)
            .Because("Repository interfaces should only be implemented in the Infrastructure layer")
            .Check(Architecture);
    }
}
