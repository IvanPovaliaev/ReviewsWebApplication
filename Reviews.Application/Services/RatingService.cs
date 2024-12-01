using Microsoft.EntityFrameworkCore;
using Reviews.Application.Interfaces;
using Reviews.Domain;
using Reviews.Domain.Models;

namespace Reviews.Application.Services
{
	public class RatingService : IRatingService
	{
		private readonly DataBaseContext _databaseContext;

		public RatingService(DataBaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}
		public async Task<Rating?> GetByProductId(int productId)
		{
			return await _databaseContext.Ratings
										 .FirstOrDefaultAsync(r => r.ProductId == productId);
		}

		public async Task<bool> CreateRatingAsync(Review newReview)
		{
			var rating = await _databaseContext.Ratings.FirstOrDefaultAsync(r => r.ProductId == newReview.ProductId);
			if (rating is not null)
			{
				return false;
			}

			try
			{
				var newRating = new Rating()
				{
					ProductId = newReview.ProductId,
					Grade = newReview.Grade,
					CreationDate = newReview.CreationDate
				};

				newRating.Reviews.Add(newReview);

				await _databaseContext.Ratings.AddAsync(newRating);
				await _databaseContext.SaveChangesAsync();

				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<bool> UpdateRatingAsync(Rating rating)
		{
			try
			{
				rating.UpdateGrade();
				_databaseContext.Ratings.Update(rating);
				await _databaseContext.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
