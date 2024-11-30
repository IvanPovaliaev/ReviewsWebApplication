using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reviews.Application.Interfaces;
using Reviews.Application.Models;
using Reviews.Domain;
using Reviews.Domain.Models;

namespace Reviews.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly DataBaseContext _databaseContext;
        private readonly IMapper _mapper;

        public ReviewService(DataBaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<List<ReviewDTO>> GetReviewsByProductId(int id)
        {
            var reviews = await _databaseContext.Reviews
                                         .Where(r => r.Status != ReviewStatus.Deleted && r.ProductId == id)
                                         .Include(r => r.Rating)
                                         .ToListAsync();
            return reviews.Select(_mapper.Map<ReviewDTO>).ToList();
        }

        public async Task<ReviewDTO?> GetReviewAsync(int id)
        {
            var review = await _databaseContext.Reviews.FindAsync(id);
            return _mapper.Map<ReviewDTO>(review);
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
