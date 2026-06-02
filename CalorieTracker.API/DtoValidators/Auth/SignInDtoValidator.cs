using CalorieTracker.Dtos.Auth;
using FluentValidation;

namespace CalorieTracker.API.DtoValidators.Auth;
public class SignInDtoValidator : AbstractValidator<SignInDto>
{
    public SignInDtoValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        ClassLevelCascadeMode = CascadeMode.Stop;

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
