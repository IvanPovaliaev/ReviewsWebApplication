using Reviews.Domain.Models;

namespace Reviews.Application.Interfaces
{
	public interface IRatingService
	{
		/// <summary>
		/// Get rating by product id
		/// </summary>
		/// <param name="productId">Product id</param>
		/// <returns>Rating model or null</returns>
		Task<Rating?> GetByProductId(int productId);

		/// <summary>
		/// Create a new rating with target review
		/// </summary>
		/// <param name="newReview">First review for rating</param>
		/// <returns>True if Rating created successfully; otherwise return false</returns>
		Task<bool> CreateRatingAsync(Review newReview);

		/// <summary>
		/// Update target rating
		/// </summary>
		/// <param name="rating">Target rating</param>
		/// <returns>True if rating updated successfully; otherwise return false</returns>
		Task<bool> UpdateRatingAsync(Rating rating);
	}
}
