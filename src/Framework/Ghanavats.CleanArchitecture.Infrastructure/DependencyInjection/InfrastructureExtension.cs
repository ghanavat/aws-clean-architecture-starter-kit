using System.Diagnostics.CodeAnalysis;
using Ghanavats.CleanArchitecture.Infrastructure.Repositories;
using Ghanavats.CleanArchitecture.UseCases.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Ghanavats.CleanArchitecture.Infrastructure.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class InfrastructureExtension
{
    extension(IServiceCollection services)
    {
        public void AddRepositories()
        {
            services.AddScoped<IPeopleRepository, PeopleRepository>();
        }
    }
}
