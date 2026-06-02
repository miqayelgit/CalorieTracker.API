using CalorieTracker.Dtos.Auth;
using FluentValidation;
namespace CalorieTracker.API.DtoValidators.Auth;

public class ResetPasswordDtoValidator : AbstractValidator<ResetPasswordDto>
{
    public ResetPasswordDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Token)
            .NotNull()
            .NotEmpty()
            .Length(1, 255);

        RuleFor(x => x.NewPassword)
            .NotNull()
            .NotEmpty()
            .Length(8, 30);
    }
}
