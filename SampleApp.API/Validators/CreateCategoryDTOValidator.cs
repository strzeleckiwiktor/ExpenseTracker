using ExpenseTracker.API.DTOs.Category;
using FluentValidation;

namespace ExpenseTracker.API.Validators
{
    public class CreateCategoryDTOValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDTOValidator()
        {
            RuleFor(dto => dto.Name)
                .MinimumLength(3)
                .WithMessage("Category name has to be minimum of 3 characters")
                .MaximumLength(100)
                .WithMessage("Category name has to be maximum of 100 characters");
        }
    }
}
