using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Ghanavats.CleanArchitecture.Core.Entities;
using Ghanavats.CleanArchitecture.Infrastructure.DynamoDbModels;
using Ghanavats.CleanArchitecture.UseCases.Contracts;

namespace Ghanavats.CleanArchitecture.Infrastructure.Repositories;

public sealed class PeopleRepository : IPeopleRepository
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
        var result = await _dbContext.LoadAsync<DynamoDbPerson>(personId);
        return result.ToDomain();
    }
}
