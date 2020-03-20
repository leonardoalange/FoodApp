using FluentValidation;
using FoodApp.Domain.Entities;
using FoodApp.Domain.Resources;

namespace FoodApp.Domain.FluentValidatiors
{
    public class CategoryValidatior : AbstractValidator<CategoryEntity>
    {
        public CategoryValidatior()
        {
            RuleFor(category => category.Name).NotNull().WithMessage(ErrorMessages.ErrorName)
                .NotEmpty().WithMessage(ErrorMessages.ErrorName)
                .Length(3, 70).WithMessage(ErrorMessages.ErrorName);
            RuleFor(category => category.Color).NotNull().WithMessage(ErrorMessages.ErrorColor)
                .NotEmpty().WithMessage(ErrorMessages.ErrorColor)
                .Length(3, 20).WithMessage(ErrorMessages.ErrorColor);
            RuleFor(category => category.Description).NotNull().WithMessage(ErrorMessages.ErrorDescription)
                .NotEmpty().WithMessage(ErrorMessages.ErrorDescription)
                .Length(3, 100).WithMessage(ErrorMessages.ErrorDescription);
        }
    }
}
