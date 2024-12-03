namespace Reviews.Application.Models
{
	public class AddReviewDTO
	{
		public int ProductId { get; init; }

		public int UserId { get; init; }

		public string? Text { get; init; }

		public int Grade { get; init; }
	}
}
