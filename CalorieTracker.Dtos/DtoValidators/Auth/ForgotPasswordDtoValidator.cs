
using CalorieTracker.Dtos.Auth;
using FluentValidation;

namespace CalorieTracker.Dtos.DtoValidators.Auth;

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
