using CalorieTracker.Dtos.Products;
using FluentValidation;

namespace CalorieTracker.API.DtoValidators.Products;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(x => x.Name)
          .NotNull()
          .Length(1, 50)
          .NotEmpty();

        RuleFor(x => x.ProteinPerHundredGram)
          .NotNull()
          .InclusiveBetween(0, 1000);

        RuleFor(x => x.CarbsPerHundredGram)
          .NotNull()
          .InclusiveBetween(0, 1000);

        RuleFor(x => x.FatPerHundredGram)
          .NotNull()
          .InclusiveBetween(0, 1000);

        RuleFor(x => x.CaloriesPerHundredGram)
          .NotNull()
          .InclusiveBetween((short)0, (short)5000);
    }
}
