using FluentValidation;
using BusinessLogic.DTOs;
using BusinessLogic.Extensions;

namespace BusinessLogic.Validators
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .Matches("[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter.");

            RuleFor(x => x.CategoryId)
                .NotEmpty();

            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} can not be negative.");

            RuleFor(x => x.Discount)
                .NotNull()
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} can not be negative.");

            RuleFor(x => x.Description)
                .Length(10, 4000)
                .Matches("[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .Must(ValidatorsExtensions.LinkMustBeAUri).WithMessage("{PropertyName} must be a valid URL address.");

            RuleFor(x => x.CityName)
                .NotEmpty()
                .MinimumLength(2)
                .Matches("[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter.");

            //RuleFor(x => x.CityId)
            //    .NotEmpty();
        }
    }
}
