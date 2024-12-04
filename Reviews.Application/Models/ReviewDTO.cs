using Reviews.Domain.Models;

namespace Reviews.Application.Models
{
    public class ReviewDTO
    {
        public int Id { get; init; }

        public Guid ProductId { get; init; }

        public string UserId { get; init; }

        public string? Text { get; set; }

        public int Grade { get; set; }

        public DateTime CreationDate { get; set; }

        public int RatingId { get; init; }

        public ReviewStatus Status { get; set; }
    }
}
