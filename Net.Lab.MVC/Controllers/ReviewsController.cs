using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Net.Lab.Common.Interfaces;
using Net.Lab.DAL.Exceptions;
using Net.Lab.DataContracts.Reviews;

namespace Net.Lab.MVC.Controllers
{
    [Route("[controller]/")]
    public class ReviewsController : Controller
    {
        private readonly ILogger<ReviewsController> logger;
        private readonly IReviewsService reviewsService;

        public ReviewsController(ILogger<ReviewsController> logger, IReviewsService reviewsService)
        {
            this.logger = logger;
            this.reviewsService = reviewsService;
        }

        public async Task<IActionResult> Index()
        {
            // var allReviews = await reviewsService.GetReviewsAsync();
            var allReviews = reviewsService.GetReviews();

            return View(allReviews);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Review review)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                // await reviewsService.CreateReviewAsync(review);
                reviewsService.CreateReview(review);

                return RedirectToAction(nameof(Index));
            }
            catch (InvalidReviewException)
            {
                ModelState.AddModelError("GameId", "GameId should point to the existing game.");
                return View();
            }
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            // return View(await reviewsService.GetReviewAsync(id));
            return View(reviewsService.GetReview(id));
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, Review review)
        {
            try
            {
                review.Id = id;

                if (!ModelState.IsValid)
                {
                    return View();
                }

                // await reviewsService.EditReviewAsync(id, review);
                reviewsService.EditReview(id, review);

                return RedirectToAction(nameof(Index));
            }
            catch (InvalidReviewException)
            {
                ModelState.AddModelError("GameId", "GameId should point to the existing game.");
                return View();
            }
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // return View(await reviewsService.GetReviewAsync(id));
            return View(reviewsService.GetReview(id));
        }


        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(int id, Review review)
        {
            try
            {
                // await reviewsService.DeleteReviewAsync(id);
                reviewsService.DeleteReview(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}