using FluentValidation;
using Ghanavats.CleanArchitecture.Core.Entities;
using Ghanavats.CleanArchitecture.UseCases.GerPersonDetails.Requests;
using Ghanavats.ResultPattern;
using Microsoft.Extensions.Logging;

namespace Ghanavats.CleanArchitecture.UseCases.GerPersonDetails;

public interface IGetPersonDetails
{
    Task<Result<Person>> GetDetails(GetPersonDetailsRequest request);
}

/// <summary>
/// A greatly simplified sample use-case to fetch/create Person data.
/// </summary>
public class GetPersonDetailsUseCase : IGetPersonDetails
{
    private readonly IValidator<GetPersonDetailsRequest> _validator;
    private readonly ILogger<GetPersonDetailsUseCase> _logger;

    public GetPersonDetailsUseCase(IValidator<GetPersonDetailsRequest> validator, ILogger<GetPersonDetailsUseCase> logger)
    {
        _validator = validator;
        _logger = logger;
    }

    public async Task<Result<Person>> GetDetails(GetPersonDetailsRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            if (_logger.IsEnabled(LogLevel.Error))
            {
                _logger.LogError("{ValidationResult}", validationResult.Errors);
            }

            return Result.Invalid(validationResult);
        }

        var person = new Person
        {
            Name = "SomeName",
            Email = "SomeEmail",
            Phone = "SomePhone",
            DateOfBirth = new DateTime(2000, 1, 1)
        };

        return Result<Person>.Success(person);
    }
}
