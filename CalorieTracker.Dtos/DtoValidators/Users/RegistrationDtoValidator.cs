using CalorieTracker.Dtos.Users;
using FluentValidation;

namespace CalorieTracker.Dtos.DtoValidators.Users
{
    public class RegistrationDtoValidator : AbstractValidator<RegistrationDto>
    {
        public RegistrationDtoValidator()
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

            RuleFor(x => x.Password)
                .MinimumLength(8)
                .MaximumLength(20);
        }
    }
}
