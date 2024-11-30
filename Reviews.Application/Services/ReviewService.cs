using Microsoft.EntityFrameworkCore;
using Reviews.Domain;
using Reviews.Domain.Interfaces;
using Reviews.Domain.Models;

namespace Reviews.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly DataBaseContext databaseContext;

        public ReviewService(DataBaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<List<Review>> GetFeedbacks(int id)
        {
            return await databaseContext.Reviews
                                        .Where(r => r.Status != FeedbackStatus.Deleted)
                                        .ToListAsync();
        }

        public async Task<IEnumerable<Review?>> GetReviewAsync(int id, int productId)
        {
            return await databaseContext.Reviews.Where(x => x.Id == id)
                                                  .ToListAsync();
        }

        public async Task<bool> TryToDeleteReviewAsync(int id)
        {
            try
            {
                var Review = await databaseContext.Reviews.Where(x => x.Id == id)
                                                            .FirstOrDefaultAsync();

                databaseContext.Reviews.Remove(Review!);
                await databaseContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
