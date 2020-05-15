using System;
using System.Collections.Generic;
using Net.Lab.DataContracts.Reviews;

namespace Net.Lab.Common.Interfaces
{
    public interface IReviewsService
    {
        IEnumerable<Review> GetReviews();

        Review GetReview(int reviewId);

        void CreateReview(Review review);

        void EditReview(int reviewId, Review review);

        void DeleteReview(int reviewId);
    }
}
