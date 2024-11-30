using Microsoft.EntityFrameworkCore;
using Reviews.Domain;
using Reviews.Domain.Interfaces;
using Reviews.Domain.Models;

namespace Reviews.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly DataBaseContext _databaseContext;

        public ReviewService(DataBaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<Review>> GetReviewsByProductId(int id)
        {
            return await _databaseContext.Reviews
                                         .Where(r => r.Status != ReviewStatus.Deleted && r.ProductId == id)
                                         .Include(r => r.Rating)
                                         .ToListAsync();
        }

        public async Task<Review?> GetReviewAsync(int id)
        {
            return await _databaseContext.Reviews.FindAsync(id);
        }

        public async Task<bool> TryDeleteReviewAsync(int id)
        {
            try
            {
                var review = await _databaseContext.Reviews.FindAsync(id);
                review.Status = ReviewStatus.Deleted;

                await _databaseContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
