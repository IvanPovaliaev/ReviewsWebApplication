namespace Reviews.Domain.Models
{
	public class Review
	{
		public int Id { get; init; }
		public int ProductId { get; init; }
		public int UserId { get; init; }
		public string? Text { get; set; }
		public int Grade { get; set; }
		public DateTime CreationDate { get; set; } = DateTime.UtcNow;
		public int RatingId { get; init; }
		public Rating Rating { get; init; }
		public ReviewStatus Status { get; set; } = ReviewStatus.Actual;
	}
}
