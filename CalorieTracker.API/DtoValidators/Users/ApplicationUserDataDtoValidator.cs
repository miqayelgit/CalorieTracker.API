using CalorieTracker.Dtos.Users;
using FluentValidation;

namespace CalorieTracker.API.DtoValidators.Users;

public class ApplicationUserDataDtoValidator : AbstractValidator<ApplicationUserDataDto>
{
    public ApplicationUserDataDtoValidator()
    {
        RuleFor(x => x.ActivityLevelId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.FitnessGoalId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Height)
            .NotNull()
            .NotEmpty()
            .InclusiveBetween((short)1, (short)300);

        RuleFor(x => x.Weight)
            .NotNull()
            .NotEmpty()
            .InclusiveBetween((short)1, (short)500);

        RuleFor(x => x.Age)
            .NotNull()
            .NotEmpty()
            .InclusiveBetween((byte)1, (byte)120);

        RuleFor(x => x.Gender)
            .NotNull()
            .NotEmpty()
            .MaximumLength(6);
    }
}
