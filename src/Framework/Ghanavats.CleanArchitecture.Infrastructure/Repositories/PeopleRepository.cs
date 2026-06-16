using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Ghanavats.CleanArchitecture.Core.Entities;
using Ghanavats.CleanArchitecture.Infrastructure.DynamoDbModels;
using Ghanavats.CleanArchitecture.UseCases.Contracts;

namespace Ghanavats.CleanArchitecture.Infrastructure.Repositories;

internal sealed class PeopleRepository : IPeopleRepository    
{
    private readonly DynamoDBContext _dbContext;

    public PeopleRepository()
    {
        var clientConfig = new AmazonDynamoDBConfig
        {
            RegionEndpoint = RegionEndpoint.EUWest1
        };

        var client = new AmazonDynamoDBClient(clientConfig);
        _dbContext = new DynamoDBContextBuilder().WithDynamoDBClient(() => client).Build();
    }

    public async Task<Person> GetPersonById(Guid personId)
    {
        var result = await _dbContext.LoadAsync<DynamoDbPerson>(personId.ToString("D"));
        return result.ToDomain();
    }

    public async Task CreatePerson(Person person)
    {
        var newItem = Person.Create("Test1", "test1@domcin.com", "123456", new DateTime(1990, 01, 01).ToString("yyyy-MM-dd"));
        var dynamoDbPerson = new DynamoDbPerson
        {
            PersonId = newItem.Id.ToString("D"),
            Name = newItem.Name,
            Email = newItem.Email,
            Phone = newItem.Phone,
            DateOfBirth = newItem.DateOfBirth
        };

        await _dbContext.SaveAsync(dynamoDbPerson);
    }
}
