using BookApi.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookApi.Validator
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.id)
                .NotEmpty()
                .Must(IsIdPositiveNumber)
                .WithMessage("Invalid Id, Id should be a positive number");
            RuleFor(b => b.name)
                .NotNull()
                .Must(IsStringContainsOnlyLetters)
                .WithMessage("Name should be letters only");
            RuleFor(b => b.category)
                .NotNull()
                .Must(IsStringContainsOnlyLetters)
                .WithMessage("Category should be letters only");
            RuleFor(b => b.author)
                .NotNull()
                .Must(IsStringContainsOnlyLetters)
                .WithMessage("AuthorName should be letters only");
        }

        public static bool IsStringContainsOnlyLetters(string value)
        {
            return Regex.IsMatch(value, @"^[a-zA-Z]+$");
        }
        public static bool IsIdPositiveNumber(int id)
        {
            return id > 0;
        }
    }
}
