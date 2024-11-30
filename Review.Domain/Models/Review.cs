namespace Reviews.Domain.Models
{
    /// <summary>
    /// Отзыв
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Id отзыва
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Id продукта
        /// </summary>
        public int ProductId { get; init; }

        /// <summary>
        /// Id пользователя, оставившего отзыв
        /// </summary>
        public int UserId { get; init; }

        /// <summary>
        /// Текст отзыва
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// Оценка (количество звезд)
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }

        public int RatingId { get; init; }

        public Rating Rating { get; init; }

        public ReviewStatus Status { get; set; }
    }
}
