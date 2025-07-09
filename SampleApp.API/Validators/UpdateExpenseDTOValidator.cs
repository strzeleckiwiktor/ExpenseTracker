﻿using ExpenseTracker.API.DTOs.Expense;
using FluentValidation;

namespace ExpenseTracker.API.Validators
{
    public class UpdateExpenseDTOValidator : AbstractValidator<UpdateExpenseDTO>
    {
        public UpdateExpenseDTOValidator()
        {
            RuleFor(dto => dto.Name)
                .MinimumLength(3)
                .WithMessage("Expense name has to be minimum of 3 characters")
                .MaximumLength(100)
                .WithMessage("Expense name has to be maximum of 100 characters");

            RuleFor(dto => dto.Amount)
                .GreaterThan(0.0)
                .WithMessage("Amount must be greater than 0");

            RuleFor(dto => dto.CategoryId)
                .NotEmpty()
                .WithMessage("Category Id must not be empty");
        }
    }
}
