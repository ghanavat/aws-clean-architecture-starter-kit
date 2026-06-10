namespace Ghanavats.CleanArchitecture.UseCases.GerPersonDetails.Requests;

public sealed class GetPersonDetailsRequest
{
    public string PersonId { get; init; } = Guid.Empty.ToString();
}
