using CalorieTracker.Dtos.Users;
using FluentValidation;

namespace CalorieTracker.API.DtoValidators.Users;

public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .NotNull()
            .Length(3, 20);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .NotNull()
            .Length(3, 30);

        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress()
            .Length(5, 60);
    }
}
