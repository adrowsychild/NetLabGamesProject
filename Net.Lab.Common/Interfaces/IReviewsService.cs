using System;
using System.Collections.Generic;
using Net.Lab.DataContracts.Reviews;

namespace Net.Lab.Common.Interfaces
{
    public interface IReviewsService
    {
        IEnumerable<Review> GetReviews(int gameId);

        Review GetReview(int gameId, int reviewId);

        void CreateReview(int gameId, Review review);

        void EditReview(int gameId, int reviewId, Review review);

        void DeleteReview(int gameId, int reviewId);
    }
}
