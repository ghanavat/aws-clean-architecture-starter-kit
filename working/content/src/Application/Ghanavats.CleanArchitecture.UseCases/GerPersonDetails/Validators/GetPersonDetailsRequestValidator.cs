using FluentValidation;
using Ghanavats.CleanArchitecture.UseCases.GerPersonDetails.Requests;

namespace Ghanavats.CleanArchitecture.UseCases.GerPersonDetails.Validators;

public class GetPersonDetailsRequestValidator : AbstractValidator<GetPersonDetailsRequest>
{
    public GetPersonDetailsRequestValidator()
    {
        RuleFor(x => x.PersonId)
            .NotEmpty().WithMessage("PersonId is required");
    }
}
