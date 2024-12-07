namespace Reviews.Domain.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public Guid ProductId { get; init; }
        public DateTime CreationDate { get; set; }
        public List<Review> Reviews { get; set; }
        public double Grade { get; set; }

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
