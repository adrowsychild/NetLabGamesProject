using System;
using System.Collections.Generic;
using System.Linq;
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
            var allReviews = reviewsService.GetReviews();

            return View(allReviews);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(Review review)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

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
        public IActionResult Edit(int id)
        {
            return View(reviewsService.GetReview(id));
        }

        [HttpPost("Edit/{id}")]
        public IActionResult Edit(int id, Review review)
        {
            try
            {
                review.Id = id;

                if (!ModelState.IsValid)
                {
                    return View();
                }

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
        public IActionResult Delete(int id)
        {
            return View(reviewsService.GetReview(id));
        }


        [HttpPost("Delete/{id}")]
        public IActionResult Delete(int id, Review review)
        {
            try
            {
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