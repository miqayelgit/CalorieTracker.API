
using CalorieTracker.Dtos.Auth;
using FluentValidation;

namespace CalorieTracker.API.DtoValidators.Auth;

public class ForgotPasswordDtoValidator : AbstractValidator<ForgotPasswordDto>
{
    public ForgotPasswordDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50);
    }
}
