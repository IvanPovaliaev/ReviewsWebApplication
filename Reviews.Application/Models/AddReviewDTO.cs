namespace Reviews.Application.Models
{
    public class AddReviewDTO
    {
        public Guid ProductId { get; init; }

        public string UserId { get; init; }

        public string? Text { get; init; }

        public int Grade { get; init; }
    }
}
