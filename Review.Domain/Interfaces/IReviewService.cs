using Reviews.Domain.Models;

namespace Reviews.Domain.Interfaces
{
    public interface IReviewService
    {
        /// <summary>
        /// Получение все отзывов по продукту
        /// </summary>
        /// <param name="productId">Id продукта</param>
        /// <returns></returns>
        Task<List<Review>> GetReviewsByProductId(int productId);

        /// <summary>
        /// Получение всех отзывов по продукту
        /// </summary>
        /// <param name="id">Id отзыва</param>
        /// <returns></returns>
        Task<Review?> GetReviewAsync(int id);

        /// <summary>
        /// Удаление отзыва
        /// </summary>
        /// <param name="id">Id отзыва</param>
        /// <returns></returns>
        Task<bool> TryDeleteReviewAsync(int id);
    }
}
