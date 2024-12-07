using Reviews.Domain.Models;

namespace Reviews.Domain.Helper
{
    public class Initialization
    {
        private const int ProductCount = 10;
        private const int MaxReviewPerRating = 10;
        private readonly Random _random = new();
        private int _reviewIndex = 1;
        private readonly string LoremIpsum = InitializationResources.LoremIpsum;

        public IEnumerable<Review> SetReviews()
        {
            for (int i = 1; i <= ProductCount; i++)
            {
                var reviewsCount = _random.Next(1, MaxReviewPerRating + 1);

                for (int j = 1; j <= reviewsCount; j++)
                {
                    yield return CreateReview(i);
                }
            }
        }

        public Review CreateReview(int ratingId)
        {
            return new Review()
            {
                Id = _reviewIndex++,
                CreationDate = DateTime.UtcNow.AddDays(_random.Next(-100, 0)),
                Grade = _random.Next(0, 6),
                ProductId = Guid.NewGuid(),
                Text = LoremIpsum.Substring(0, _random.Next(20, 100)),
                UserId = Guid.NewGuid().ToString(),
                Status = (ReviewStatus)_random.Next(0, 3),
                RatingId = ratingId
            };
        }

        public IEnumerable<Rating> SetRatings(IEnumerable<Review> reviews)
        {
            var reviewsPerRating = reviews.ToLookup(r => r.RatingId);

            foreach (var ratingReview in reviewsPerRating)
            {
                var rating = new Rating()
                {
                    Id = ratingReview.Key,
                    CreationDate = DateTime.UtcNow.AddDays(_random.Next(-100, 0)),
                    ProductId = ratingReview.First().ProductId,
                    Reviews = ratingReview.ToList()
                };

                rating.UpdateGrade();
                rating.Reviews = new List<Review>();

                yield return rating;
            }
        }

        public static List<Login> SetLogins()
        {
            var results = new List<Login>();
            var firstLogin = new Login()
            {
                Id = 1,
                UserName = "admin",
                Password = "admin"
            };

            results.Add(firstLogin);
            return results;
        }
    }
}
