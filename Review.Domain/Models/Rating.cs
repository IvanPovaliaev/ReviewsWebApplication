﻿namespace Reviews.Domain.Models
{
    /// <summary>
    /// Рейтинг
    /// </summary>
    public class Rating
    {
        /// <summary>
        /// Id рейтинга
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id продукта
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// отзывы
        /// </summary>
        public List<Review> Reviews { get; set; }

        public double Grade { get; private set; }

        public Rating()
        {
            Reviews = new List<Review>();
        }

        public void UpdateGrade()
        {
            Grade = Math.Round(Reviews.Average(r => r.Grade), 2);
        }
    }
}
