using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reviews.Application.Interfaces;
using Reviews.Application.Models;

namespace ReviewsWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReviewController : ControllerBase
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IReviewService _reviewService;
        private readonly IValidator<AddReviewDTO> _addReviewValidator;

        public ReviewController(ILogger<ReviewController> logger, IReviewService reviewService, IValidator<AddReviewDTO> addReviewValidator)
        {
            _logger = logger;
            _reviewService = reviewService;
            _addReviewValidator = addReviewValidator;
        }

        /// <summary>
        /// Get all review by product id
        /// </summary>
        /// <returns>Collection of ReviewDTO's for target product</returns>
        /// <param name="productId">Product id</param>
        [HttpGet("GetAllByProductId")]
        public async Task<IActionResult> GetAllAsync(Guid productId)
        {
            try
            {
                var result = await _reviewService.GetReviewsByProductIdAsync(productId);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        /// <summary>
        /// Get review by id
        /// </summary>
        /// <param name="id">Review id</param>
        /// <returns>Related ReviewDTO model</returns>
        [HttpGet]
        public async Task<IActionResult> GetReviewAsync(int id)
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
        /// Add a new review
        /// </summary>
        /// <param name="newReview">newReview</param>
        /// <returns>Operation status code</returns>
        [HttpPost]
        public async Task<IActionResult> AddReviewAsync([FromBody] AddReviewDTO newReview)
        {
            var validationResult = _addReviewValidator.Validate(newReview);

            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Errors = validationResult.Errors.Select(e => new
                    {
                        Property = e.PropertyName,
                        e.ErrorMessage
                    })
                });
            }

            var result = await _reviewService.AddReviewAsync(newReview);
            return result ? Ok() : BadRequest();
        }

        /// <summary>
        /// Delete review by id
        /// </summary>
        /// <param name="id">Review id</param>
        /// <returns>True if review deleted successfully; otherwise return false</returns>
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteReviewAsync(int id)
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