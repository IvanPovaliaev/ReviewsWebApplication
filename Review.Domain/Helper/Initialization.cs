using Reviews.Domain.Models;

namespace Reviews.Domain.Helper
{
    public class Initialization
    {
        private const int ProductCount = 10;
        private const int MaxReviewPerRating = 10;
        private readonly Random _random = new();
        private int _reviewIndex = 1;

        private const string LoremIpsum = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

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

        public Review CreateReview(int productId)
        {
            return new Review()
            {
                Id = _reviewIndex++,
                CreationDate = DateTime.UtcNow.AddDays(_random.Next(-100, 0)),
                Grade = _random.Next(0, 6),
                ProductId = productId,
                Text = LoremIpsum.Substring(0, _random.Next(20, 100)),
                UserId = _random.Next(1, 10),
                Status = (ReviewStatus)_random.Next(0, 3),
                RatingId = productId
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
                    ProductId = ratingReview.Key,
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
