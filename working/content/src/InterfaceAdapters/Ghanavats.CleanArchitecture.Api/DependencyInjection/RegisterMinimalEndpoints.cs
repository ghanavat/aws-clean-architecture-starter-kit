using System.Diagnostics.CodeAnalysis;
using Ghanavats.CleanArchitecture.Api.Endpoints;
using Ghanavats.CleanArchitecture.Api.Extensions;

namespace Ghanavats.CleanArchitecture.Api.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class RegisterMinimalEndpoints
{
    extension(WebApplication app)
    {
        public void RegisterEndpoints()
        {
            app.PeopleGroup();
            GetPersonDetailsEndpoint.Get(app);
        }
    }
}
