using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reviews.Domain.Interfaces;
using Reviews.Domain.Models;

namespace ReviewsWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ReviewController : ControllerBase
    {

        private readonly ILogger<ReviewController> _logger;
        private readonly IReviewService reviewService;

        public ReviewController(ILogger<ReviewController> logger, IReviewService reviewService)
        {
            _logger = logger;
            this.reviewService = reviewService;
        }

        /// <summary>
        /// Получение всех отзывов по продукту
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFeedbacksByProductId")]
        public async Task<ActionResult<List<Review>>> GetAllReviewsAsync(int id)
        {
            try
            {
                var result = await reviewService.GetFeedbacks(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        /// <summary>
        /// Получение отзыва
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetReview")]
        public async Task<ActionResult<List<Review>>> GetReviewAsync(int feedbackId, int productId)
        {
            try
            {
                var result = await reviewService.GetReviewAsync(feedbackId, productId);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        /// <summary>
        /// Удаление отзыва по id
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("DeleteReview")]
        public async Task<ActionResult<List<Review>>> DeleteReviewAsync(int id)
        {
            try
            {
                var result = await reviewService.TryToDeleteReviewAsync(id);
                if (result)
                {
                    return Ok();
                }

                return BadRequest(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }
    }
}