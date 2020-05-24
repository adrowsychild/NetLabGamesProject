using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Net.Lab.DAL.Exceptions;
using Net.Lab.DAL.Repositories.Interfaces;
using Net.Lab.DataContracts.Reviews;

namespace Net.Lab.DAL.Repositories.Implementations
{
    public class InMemoryReviewsRepository : IReviewsRepository
    {
        private List<Review> repository;
        private readonly IGamesRepository gamesRepository;
        private int idCount = 4;

        public InMemoryReviewsRepository(IGamesRepository gamesRepository)
        {
            this.gamesRepository = gamesRepository;
            if (repository == null)
                repository = new List<Review>()
                {
                    new Review() { Id = 1, GameId = 1, IsPositive = true, Author = "Hooked Gamers", Description = "It is an outstanding creation I highly encourage anyone to go out and buy this game." },
                    new Review() { Id = 2, GameId = 1, IsPositive = true, Author = "Vandal", Description = "Undertale is a masterpiece. Fresh, fun and unique, and one of those games you should play if you think you love video games." },
                    new Review() { Id = 3, GameId = 2, IsPositive = true, Author = "3DJuegos", Description = "DOTA 2 it's amazing. One of the best MOBA around. It needs a lot of practice to be mastered, but if you play MOBAs, then it is for you." },
                };
        }

        public Review GetReview(int id)
        {
            var result = repository.Find(x => x.Id == id);
            if (result == null)
                throw new ReviewNotFoundException();

            return result;
        }

        public IEnumerable<Review> GetReviews()
        {
            if (repository.Count == 0)
                throw new ReviewNotFoundException();

            return repository.ToArray();
        }

        public void CreateReview(Review review)
        {
            if (isInvalidReview(review))
                throw new InvalidReviewException(review);

            review.Id = idCount++;
            if (GameExists(review.GameId))
                repository.Add(review);
            else
                throw new InvalidReviewException(review);
        }

        private bool GameExists(int gameId)
        {
            try
            {
                gamesRepository.GetGame(gameId);
                return true;
            }
            catch (GameNotFoundException)
            {
                return false;
            }
        }

        private bool isInvalidReview(Review review)
        {
            if (review == null || !GameExists(review.GameId))
                return true;
            else
                return false;
        }

        public void EditReview(int id, Review review)
        {
            if (review.Id != id)
                throw new InvalidReviewException(review);
            // message: "Game object should contain the same Id as Id to put it at."

            if (isInvalidReview(review))
                throw new InvalidReviewException(review);

            for (int i = 0; i < repository.Count; i++)
            {
                if (repository[i].Id == review.Id)
                {
                    repository[i] = review;
                    return;
                }
            }

            throw new ReviewNotFoundException();
        }

        public void DeleteReview(int id)
        {
            var result = repository.Find(x => x.Id == id);
            if (result == null)
                throw new ReviewNotFoundException();

            repository.Remove(result);
        }

        public Task<IEnumerable<Review>> GetReviewsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Review> GetReviewAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateReviewAsync(Review review)
        {
            throw new NotImplementedException();
        }

        public Task EditReviewAsync(int id, Review review)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReviewAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
