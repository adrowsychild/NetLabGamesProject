using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Net.Lab.Common.Interfaces;
using Net.Lab.DAL.Exceptions;
using Net.Lab.DataContracts.Games;

namespace Net.Lab.CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private static IGamesService gamesService;
        private readonly IMemoryCache cache;
        private string gamekey = "game";
        string allGamesKey = "game000";

        //private static IAwardsService awardsService;
        //private static IReviewsService reviewsService;

        public GamesController(IGamesService gamesService, IMemoryCache cache)
        {
            this.cache = cache;
            // try without it
            if (GamesController.gamesService == null)
                GamesController.gamesService = gamesService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetAllGames()
        {
            try
            {
                if (!cache.TryGetValue(allGamesKey, out IEnumerable<Game> result))
                {
                    result = gamesService.GetGames();
                    cache.Set(allGamesKey, result);
                }
                
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
                if (!cache.TryGetValue(gamekey + id, out Game result))
                {
                    result = gamesService.GetGame(id);
                    cache.Set(gamekey + id, result);
                }

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                gamesService.CreateGame(game);
                ClearAllGamesCache();
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
                cache.Set(gamekey + id, game);
                ClearAllGamesCache();
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
                cache.Remove(gamekey + id);
                ClearAllGamesCache();
                return Ok();
            }
            catch (GameNotFoundException)
            {
                return NotFound();
            }
        }

        private void ClearAllGamesCache()
        {
            cache.Remove(allGamesKey);
        }

        /*
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

    */
    }
}