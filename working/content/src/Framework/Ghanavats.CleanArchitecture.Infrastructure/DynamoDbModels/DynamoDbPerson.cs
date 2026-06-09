using Amazon.DynamoDBv2.DataModel;
using Ghanavats.CleanArchitecture.Core.Entities;

namespace Ghanavats.CleanArchitecture.Infrastructure.DynamoDbModels;

[DynamoDBTable("People")]
public sealed class DynamoDbPerson
{
    [DynamoDBHashKey(AttributeName =  "PersonId")]
    public Guid PersonId { get; init; }
    [DynamoDBProperty]
    public string Name { get; init; } = string.Empty;
    [DynamoDBProperty]
    public string Email { get; init; } = string.Empty;
    [DynamoDBProperty]
    public string Phone { get; init; } = string.Empty;
    [DynamoDBProperty]
    public DateTime DateOfBirth { get; init; } = DateTime.MinValue;
}

internal static class PersonMapper
{
    extension(DynamoDbPerson? source)
    {
        public Person ToDomain()
        {
            if (source is null)
            {
                return new Person();
            }
            
            return Person.Rehydrate(source.PersonId, 
                source.Name, source.Email, 
                source.Phone,  source.DateOfBirth);
        }
    }
}
