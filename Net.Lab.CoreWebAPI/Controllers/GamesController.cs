using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Net.Lab.Common.Implementations;
using Net.Lab.Common.Interfaces;
using Net.Lab.DAL.Exceptions;
using Net.Lab.DataContracts.Awards;
using Net.Lab.DataContracts.Games;
using Net.Lab.DataContracts.Reviews;

namespace Net.Lab.CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private static IGamesService gamesService;

        private static IAwardsService awardsService;

        private static IReviewsService reviewsService;

        public GamesController(IGamesService gamesService)
        {
            if (GamesController.gamesService == null)
                GamesController.gamesService = gamesService;

            if (awardsService == null)
                awardsService = new AwardsService(gamesService);

            if (reviewsService == null)
                reviewsService = new ReviewsService(gamesService);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetAllGames()
        {
            try
            {
                var result = gamesService.GetGames();
                return Ok(result);
            }
            catch (GameNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Game> GetGame(int id)
        {
            try
            {
                var result = gamesService.GetGame(id);
                return Ok(result);
            }
            catch (GameNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateGame(Game game)
        {
            try
            {
                gamesService.CreateGame(game);
                return Created("", game);
            }
            catch (InvalidGameException)
            {
                return BadRequest(game);
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditGame(int id, Game game)
        {
            try
            {
                gamesService.EditGame(id, game);
                return Ok();
            }
            catch (InvalidGameException)
            {
                return BadRequest();
            }
            catch (GameNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            try
            {
                gamesService.DeleteGame(id);
                return Ok();
            }
            catch (GameNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{gameId}/awards")]
        public ActionResult<IEnumerable<Award>> GetGameAwards(int gameId)
        {
            try
            {
                var result = awardsService.GetAwards(gameId);
                return Ok(result);
            }
            catch (GameNotFoundException)
            {
                return NotFound();
            }
            catch (AwardNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{gameId}/awards/{awardId}")]
        public ActionResult<Award> GetGameAward(int gameId, int awardId)
        {
            try
            {
                var result = awardsService.GetAward(gameId, awardId);
                return Ok(result);
            }
            catch (GameNotFoundException)
            {
                return NotFound();
            }
            catch (AwardNotFoundException)
            {
                return NotFound();
            }
        }


        [HttpPost("{gameId}/awards")]
        public ActionResult<Award> CreateGameAward(int gameId, Award award)
        {
            try
            {
                awardsService.CreateAward(gameId, award);
                return Created("", award);
            }
            catch (InvalidAwardException)
            {
                return BadRequest(award);
            }
            catch (AwardNotFoundException)
            {
                return NotFound();
            }
            catch (GameNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{gameId}/awards/{awardId}")]
        public ActionResult<Award> EditGameAward(int gameId, int awardId, Award award)
        {
            try
            {
                awardsService.EditAward(gameId, awardId, award);
                return Ok();
            }
            catch (InvalidAwardException)
            {
                return BadRequest(award);
            }
            catch (AwardNotFoundException)
            {
                return NotFound();
            }
            catch (GameNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{gameId}/awards/{awardId}")]
        public ActionResult<Award> DeleteGameAward(int gameId, int awardId)
        {
            try
            {
                awardsService.DeleteAward(gameId, awardId);
                return Ok();
            }
            catch (AwardNotFoundException)
            {
                return NotFound();
            }
            catch (GameNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{gameId}/reviews")]
        public ActionResult<IEnumerable<Review>> GetGameReviews(int gameId)
        {
            try
            {
                var result = reviewsService.GetReviews(gameId);
                return Ok(result);
            }
            catch (GameNotFoundException)
            {
                return NotFound();
            }
            catch (ReviewNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{gameId}/reviews/{reviewId}")]
        public ActionResult<Review> GetGameReview(int gameId, int reviewId)
        {
            try
            {
                var result = reviewsService.GetReview(gameId, reviewId);
                return Ok(result);
            }
            catch (GameNotFoundException)
            {
                return NotFound();
            }
            catch (ReviewNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("{gameId}/reviews")]
        public ActionResult<Review> CreateGameReview(int gameId, Review review)
        {
            try
            {
                reviewsService.CreateReview(gameId, review);
                return Created("", review);
            }
            catch (InvalidReviewException)
            {
                return BadRequest(review);
            }
            catch (ReviewNotFoundException)
            {
                return NotFound();
            }
            catch (GameNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{gameId}/reviews/{reviewId}")]
        public ActionResult<Review> EditGameReview(int gameId, int reviewId, Review review)
        {
            try
            {
                reviewsService.EditReview(gameId, reviewId, review);
                return Ok();
            }
            catch (InvalidReviewException)
            {
                return BadRequest(review);
            }
            catch (ReviewNotFoundException)
            {
                return NotFound();
            }
            catch (GameNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{gameId}/reviews/{reviewId}")]
        public ActionResult<Review> DeleteGameReview(int gameId, int reviewId)
        {
            try
            {
                reviewsService.DeleteReview(gameId, reviewId);
                return Ok();
            }
            catch (ReviewNotFoundException)
            {
                return NotFound();
            }
            catch (GameNotFoundException)
            {
                return NotFound();
            }
        }
    }
}