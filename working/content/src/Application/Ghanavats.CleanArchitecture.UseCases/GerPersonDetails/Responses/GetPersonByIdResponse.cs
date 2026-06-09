using Ghanavats.CleanArchitecture.Core.Entities;

namespace Ghanavats.CleanArchitecture.UseCases.GerPersonDetails.Responses;

public sealed class GetPersonByIdResponse
{
    public Guid PersonId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
}

public static class ResponseMapper
{
    extension(Person source)
    {
        public GetPersonByIdResponse ToResponse()
        {
            return new GetPersonByIdResponse
            {
                PersonId = source.Id,
                Name = source.Name,
                Email = source.Email,
                Phone = source.Phone,
                DateOfBirth = source.DateOfBirth
            };
        }
    }
}
