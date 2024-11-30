using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reviews.Domain.Interfaces;
using Reviews.Domain.Models;

namespace ReviewsWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReviewController : ControllerBase
    {

        private readonly ILogger<ReviewController> _logger;
        private readonly IReviewService _reviewService;

        public ReviewController(ILogger<ReviewController> logger, IReviewService reviewService)
        {
            _logger = logger;
            _reviewService = reviewService;
        }

        /// <summary>
        /// Получение всех отзывов по продукту
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllByProductId")]
        public async Task<ActionResult<List<Review>>> GetAllAsync(int productId)
        {
            try
            {
                var result = await _reviewService.GetReviewsByProductId(productId);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        /// <summary>
        /// Получение отзыва по Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Review>>> GetReviewAsync(int id)
        {
            try
            {
                var result = await _reviewService.GetReviewAsync(id);
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
        [HttpDelete]
        public async Task<ActionResult<List<Review>>> DeleteReviewAsync(int id)
        {
            try
            {
                var result = await _reviewService.TryDeleteReviewAsync(id);

                return result ? Ok() : BadRequest(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }
    }
}