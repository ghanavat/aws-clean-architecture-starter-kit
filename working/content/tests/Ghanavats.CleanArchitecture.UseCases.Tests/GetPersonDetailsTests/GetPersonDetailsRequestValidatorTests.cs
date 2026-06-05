using FluentValidation.TestHelper;
using Ghanavats.CleanArchitecture.UseCases.GerPersonDetails.Requests;
using Ghanavats.CleanArchitecture.UseCases.GerPersonDetails.Validators;

namespace Ghanavats.CleanArchitecture.UseCases.Tests.GetPersonDetailsTests;

public class GetPersonDetailsRequestValidatorTests
{
    private readonly GetPersonDetailsRequestValidator _validator;

    public GetPersonDetailsRequestValidatorTests()
    {
        _validator = new GetPersonDetailsRequestValidator();
    }

    [Fact]
    public async Task ValidatePersonId_ShouldFail_WhenPersonIdIsInvalid()
    {
        //Arrange
        var expectedRequest = new GetPersonDetailsRequest
        {
            PersonId = 0
        };

        //Act
        var actual = await _validator.TestValidateAsync(expectedRequest, cancellationToken: TestContext.Current.CancellationToken);
        
        //Assert
        actual.ShouldHaveValidationErrorFor(x => x.PersonId);
    }
    
    [Fact]
    public async Task ValidatePersonId_ShouldPass_WhenPersonIdIsValid()
    {
        //Arrange
        var expectedRequest = new GetPersonDetailsRequest
        {
            PersonId = 12345
        };

        //Act
        var actual = await _validator.TestValidateAsync(expectedRequest, cancellationToken: TestContext.Current.CancellationToken);
        
        //Assert
        actual.ShouldNotHaveValidationErrorFor(x => x.PersonId);
    }
}
