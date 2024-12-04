using FluentValidation;
using Reviews.Application.Models;

namespace Reviews.Application.Validations
{
    public class AddReviewDTOValidator : AbstractValidator<AddReviewDTO>
    {
        public AddReviewDTOValidator()
        {
            RuleFor(x => x.ProductId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Grade)
                .InclusiveBetween(1, 5)
                .WithMessage("Grade must be between 1 and 5.");
        }
    }
}
