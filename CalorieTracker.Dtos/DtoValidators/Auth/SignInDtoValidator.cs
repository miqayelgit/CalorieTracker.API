using CalorieTracker.Dtos.Auth;
using FluentValidation;

namespace CalorieTracker.Dtos.DtoValidators.Auth;
public class SignInDtoValidator : AbstractValidator<SignInDto>
{
    public SignInDtoValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .NotNull()
            .Length(3, 50);

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .Length(8, 50);
    }
}
