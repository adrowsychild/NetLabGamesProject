using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Net.Lab.Common.Interfaces;
using Net.Lab.DAL.Exceptions;
using Net.Lab.DataContracts.Reviews;

namespace Net.Lab.CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private static IReviewsService reviewsService;
        private readonly IMemoryCache cache;
        private string reviewkey = "review";
        private string allReviewsKey = "reviews000";

        public ReviewsController(IReviewsService reviewsService, IMemoryCache cache)
        {
            this.cache = cache;

            ReviewsController.reviewsService = reviewsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Review>> GetAllReviews()
        {
            try
            {
                if (!cache.TryGetValue(allReviewsKey, out IEnumerable<Review> result))
                {
                    result = reviewsService.GetReviews();
                    cache.Set(allReviewsKey, result);
                }
                return Ok(result);
            }
            catch (ReviewNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Review> GetReview(int id)
        {
            try
            {
                if (!cache.TryGetValue(reviewkey + id, out Review result))
                {
                    result = reviewsService.GetReview(id);
                    cache.Set(reviewkey + id, result);
                }

                return Ok(result);
            }
            catch (ReviewNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateReview(Review review)
        {
            try
            {
                reviewsService.CreateReview(review);
                ClearAllReviewsCache();
                return Created("", review);
            }
            catch (InvalidReviewException)
            {
                return BadRequest(review);
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditReview(int id, Review review)
        {
            try
            {
                reviewsService.EditReview(id, review);
                cache.Set(reviewkey + id, review);
                ClearAllReviewsCache();
                return Ok();
            }
            catch (InvalidReviewException)
            {
                return BadRequest();
            }
            catch (ReviewNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
            try
            {
                reviewsService.DeleteReview(id);
                cache.Remove(reviewkey + id);
                ClearAllReviewsCache();
                return Ok();
            }
            catch (ReviewNotFoundException)
            {
                return NotFound();
            }
        }

        private void ClearAllReviewsCache()
        {
            cache.Remove(allReviewsKey);
        }
    }
}