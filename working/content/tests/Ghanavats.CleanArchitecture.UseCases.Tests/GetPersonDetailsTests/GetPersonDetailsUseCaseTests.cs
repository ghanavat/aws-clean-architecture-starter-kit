using FluentValidation;
using FluentValidation.Results;
using Ghanavats.CleanArchitecture.UseCases.GerPersonDetails;
using Ghanavats.CleanArchitecture.UseCases.GerPersonDetails.Requests;
using Ghanavats.ResultPattern.Enums;
using Microsoft.Extensions.Logging;
using Moq;

namespace Ghanavats.CleanArchitecture.UseCases.Tests.GetPersonDetailsTests;

public class GetPersonDetailsUseCaseTests
{
    private readonly Mock<IValidator<GetPersonDetailsRequest>> _validatorMock;
    private readonly Mock<ILogger<GetPersonDetailsUseCase>> _loggerMock;
    private readonly GetPersonDetailsUseCase _sut;
    
    public GetPersonDetailsUseCaseTests()
    {
        _validatorMock = new Mock<IValidator<GetPersonDetailsRequest>>();
        _loggerMock = new Mock<ILogger<GetPersonDetailsUseCase>>();
        _sut = new GetPersonDetailsUseCase(_validatorMock.Object, _loggerMock.Object);
    }
    
    [Fact]
    public async Task GetDetails_ShouldReturnInvalidResult_WhenValidationFails()
    {
        //Arrange
        var expectedRequest = new GetPersonDetailsRequest
        {
            PersonId = 0
        };
        
        _validatorMock.Setup(x => x.ValidateAsync(It.IsAny<GetPersonDetailsRequest>())).ReturnsAsync(new ValidationResult
        {
            Errors = [new ValidationFailure("SomeProperty", "SomeProperty is required.")]
        });
        
        _loggerMock.Setup(x => x.IsEnabled(It.IsAny<LogLevel>())).Returns(true);
        
        //Act
        var actual = await _sut.GetDetails(expectedRequest);
        
        //Assert
        Assert.NotNull(actual);
        Assert.Equal(ResultStatus.Invalid, actual.Status);
    }
    
    [Fact]
    public async Task GetDetails_ShouldReturnSuccessResult_WhenValidationPassed()
    {
        //Arrange
        var expectedRequest = new GetPersonDetailsRequest
        {
            PersonId = 1234
        };
        
        _validatorMock.Setup(x => x.ValidateAsync(It.IsAny<GetPersonDetailsRequest>())).ReturnsAsync(new ValidationResult());
        _loggerMock.Setup(x => x.IsEnabled(It.IsAny<LogLevel>())).Returns(true);
        
        //Act
        var actual = await _sut.GetDetails(expectedRequest);
        
        //Assert
        Assert.NotNull(actual);
        Assert.Equal(ResultStatus.Ok, actual.Status);
    }
}
