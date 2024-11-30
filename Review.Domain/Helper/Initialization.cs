using Reviews.Domain.Models;

namespace Reviews.Domain.Helper
{
    public static class Initialization
    {
        private const int Count = 100;
        private static readonly Random _random = new();

        private const string LoremIpsum = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        public static IEnumerable<Review> SetReviews()
        {
            for (int i = 1; i <= Count; i++)
            {
                var review = CreateReview(i);
                yield return review;
            }
        }

        public static Review CreateReview(int i)
        {
            return new Review()
            {
                Id = i,
                CreationDate = DateTime.UtcNow.AddDays(_random.Next(-100, 0)),
                Grade = _random.Next(0, 6),
                ProductId = _random.Next(1, 10),
                Text = LoremIpsum.Substring(0, _random.Next(20, 100)),
                UserId = _random.Next(1, 10),
                RatingId = _random.Next(1, 10),
                Status = (ReviewStatus)_random.Next(0, 3)
            };
        }

        public static IEnumerable<Rating> SetRatings()
        {
            for (int i = 1; i <= Count; i++)
            {
                var rating = CreateRating(i);
                yield return rating;
            }
        }

        public static Rating CreateRating(int i)
        {
            var reviewsCount = _random.Next(1, 10);
            var reviews = new List<Review>(reviewsCount);

            for (int k = 1; k <= reviewsCount; k++)
            {
                reviews.Add(CreateReview(k));
            }

            var averageGrade = reviews.Select(x => x.Grade)
                                      .Average();

            return new Rating()
            {
                Id = i,
                CreationDate = DateTime.UtcNow.AddDays(_random.Next(-100, 0)),
                ProductId = _random.Next(1, 10),
                Grade = Math.Round(averageGrade, 2)
            };
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
