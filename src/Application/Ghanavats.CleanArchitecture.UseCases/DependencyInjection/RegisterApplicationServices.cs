using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Ghanavats.CleanArchitecture.UseCases.GerPersonDetails;
using Ghanavats.CleanArchitecture.UseCases.GerPersonDetails.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Ghanavats.CleanArchitecture.UseCases.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class RegisterApplicationServices
{
    extension(IServiceCollection services)
    {
        public void AddValidators()
        {
            services.AddValidatorsFromAssemblyContaining<GetPersonDetailsRequestValidator>();
        }

        public void AddUseCases()
        {
            services.AddScoped<IGetPersonDetails, GetPersonDetailsUseCase>();
        }
    }
}
