using FluentValidation;
using Reviews.Application.Models;

namespace Reviews.Application.Validations
{
	public class AddReviewDTOValidator : AbstractValidator<AddReviewDTO>
	{
		public AddReviewDTOValidator()
		{
			RuleFor(x => x.ProductId)
			.GreaterThan(0)
			.WithMessage("ProductId must be greater than 0.");

			RuleFor(x => x.UserId)
				.GreaterThan(0)
				.WithMessage("UserId must be greater than 0.");

			RuleFor(x => x.Grade)
				.InclusiveBetween(1, 5)
				.WithMessage("Grade must be between 1 and 5.");
		}
	}
}
