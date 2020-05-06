using System;
using System.Collections.Generic;
using System.Linq;
using Net.Lab.Common.Interfaces;
using Net.Lab.DAL.Exceptions;
using Net.Lab.DataContracts.Reviews;

namespace Net.Lab.Common.Implementations
{
    public class ReviewsService : IReviewsService
    {
        private IGamesService gamesService;

        public ReviewsService(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        public IEnumerable<Review> GetReviews(int gameId)
        {
            var reviews = gamesService.GetGame(gameId).Reviews;
            if (reviews == null)
            {
                throw new ReviewNotFoundException();
            }

            return reviews;
        }

        public Review GetReview(int gameId, int reviewId)
        {
            var reviews = gamesService.GetGame(gameId).Reviews.Where(x => x.Id == reviewId).ToArray();
            if (reviews == null || reviews.Count() == 0)
                throw new ReviewNotFoundException();

            return reviews[0];
        }

        public void CreateReview(int gameId, Review review)
        {
            if (isInvalidReview(review))
                throw new InvalidReviewException(review);

            var game = gamesService.GetGame(gameId);
            var reviews = game.Reviews;
            var reviewsEdited = new Review[game.Reviews.Length + 1];
            for (int i = 0; i < game.Reviews.Length; i++)
                reviewsEdited[i] = game.Reviews[i];

            reviewsEdited[reviews.Length] = review;
            game.Reviews = reviewsEdited;
            gamesService.EditGame(gameId, game);
        }

        public void EditReview(int gameId, int reviewId, Review review)
        {
            if (isInvalidReview(review, reviewId))
                throw new InvalidReviewException(review);

            var game = gamesService.GetGame(gameId);
            var reviews = game.Reviews;
            var reviewIndex = FindReviewIndex(reviews, reviewId);
            if (reviewIndex == -1)
                throw new ReviewNotFoundException();
            reviews[reviewIndex] = review;
            game.Reviews = reviews;
            gamesService.EditGame(gameId, game);
        }

        public void DeleteReview(int gameId, int reviewId)
        {
            var game = gamesService.GetGame(gameId);
            var reviews = game.Reviews;
            var reviewIndex = FindReviewIndex(reviews, reviewId);
            if (reviewIndex == -1)
                throw new ReviewNotFoundException();
            reviews = RemoveAt(reviews, reviewIndex);
            game.Reviews = reviews;                         
            gamesService.EditGame(gameId, game);
        }

        public Review[] RemoveAt(Review[] reviews, int index)
        {
            Review[] reviewsEdited = new Review[reviews.Length - 1];
            for (int i = 0; i < reviewsEdited.Length; i++)
                if (i < index)
                    reviewsEdited[i] = reviews[i];
                else
                    reviewsEdited[i] = reviews[i + 1];

            return reviewsEdited;
        }

        private int FindReviewIndex(Review[] reviews, int reviewId)
        {
            for (int i = 0; i < reviews.Length; i++)
                if (reviews[i].Id == reviewId)
                    return i;

            return -1;
        }

        private bool isInvalidReview(Review review)
        {
            if (review == null)
                return true;
            else
                return false;
        }

        private bool isInvalidReview(Review review, int reviewId)
        {
            if (review.Id != reviewId)
                return true;
            return isInvalidReview(review);
        }
    }
}
