using Reviews.Application.Models;

namespace Reviews.Application.Interfaces
{
    public interface IReviewService
    {
        /// <summary>
        /// Get all review by product id
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <returns>Collection of ReviewDTO's for target product</returns>
        Task<List<ReviewDTO>> GetReviewsByProductIdAsync(Guid productId);

        /// <summary>
        /// Get review by id
        /// </summary>
        /// <param name="id">Review id</param>
        /// <returns>Related ReviewDTO model</returns>
        Task<ReviewDTO?> GetReviewAsync(int id);

        /// <summary>
        /// Add new Review
        /// </summary>
        /// <param name="newReview">AddReviewDTO</param>
        /// <returns>True if review added successfully; otherwise return false</returns>
        Task<bool> AddReviewAsync(AddReviewDTO newReview);

        /// <summary>
        /// Delete review by id
        /// </summary>
        /// <param name="id">Review id</param>
        /// <returns>True if review deleted successfully; otherwise return false</returns>
        Task<bool> TryDeleteReviewAsync(int id);
    }
}
