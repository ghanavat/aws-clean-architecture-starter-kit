using FluentValidation;
using Ghanavats.CleanArchitecture.UseCases.GerPersonDetails.Requests;

namespace Ghanavats.CleanArchitecture.UseCases.GerPersonDetails.Validators;

public sealed class GetPersonDetailsRequestValidator : AbstractValidator<GetPersonDetailsRequest>
{
    public GetPersonDetailsRequestValidator()
    {
        RuleFor(x => x.PersonId)
            .Must(personId => Guid.TryParse(personId, out _)).WithMessage("Invalid PersonId")
            .NotEmpty().WithMessage("PersonId is required");
    }
}
