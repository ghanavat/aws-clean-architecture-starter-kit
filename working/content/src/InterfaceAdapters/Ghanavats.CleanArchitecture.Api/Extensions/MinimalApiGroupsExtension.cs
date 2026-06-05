using System.Diagnostics.CodeAnalysis;

namespace Ghanavats.CleanArchitecture.Api.Extensions;

[ExcludeFromCodeCoverage]
public static class MinimalApiGroupsExtension
{
    extension(WebApplication app)
    {
        public RouteGroupBuilder PeopleGroup()
        {
            return app.MapGroup("/api/people")
                .AllowAnonymous();
        }
    } 
}
