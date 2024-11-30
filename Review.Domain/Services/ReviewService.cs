﻿using Microsoft.EntityFrameworkCore;
using Review.Domain.Interfaces;

namespace Review.Domain.Services
{
    public class ReviewService : IReviewService
    {
        private readonly DataBaseContext databaseContext;

        public ReviewService(DataBaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<List<Models.Review>> GetFeedbacks(int id)
        {
            return await databaseContext.Feedbacks.ToListAsync();
        }

        public async Task<IEnumerable<Models.Review?>> GetReviewAsync(int id, int productId)
        {
            return await databaseContext.Feedbacks.Where(x => x.Id == id)
                                                  .ToListAsync();
        }

        public async Task<bool> TryToDeleteReviewAsync(int id)
        {
            try
            {
                var Review = await databaseContext.Feedbacks.Where(x => x.Id == id)
                                                            .FirstOrDefaultAsync();

                databaseContext.Feedbacks.Remove(Review!);
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
