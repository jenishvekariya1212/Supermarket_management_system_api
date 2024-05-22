using FluentValidation;
using Supermarketapi.Models;

namespace Supermarketapi.Validation
{
    public class Validation:AbstractValidator<CategoryModel>
    {
        public Validation() {
            RuleFor(user => user.CategoryName).NotEmpty().WithMessage("categoryName is required.");
            RuleFor(user => user.CategoryDescription).NotEmpty().WithMessage("CategoryDescription is required.");
        }
    }
}
