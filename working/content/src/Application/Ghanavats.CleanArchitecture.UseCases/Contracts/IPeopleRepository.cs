using Ghanavats.CleanArchitecture.Core.Entities;

namespace Ghanavats.CleanArchitecture.UseCases.Contracts;

public interface IPeopleRepository
{
    Task<Person> GetPersonById(Guid personId);
}
