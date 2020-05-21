using System;
using System.Collections.Generic;
using Net.Lab.DataContracts.Reviews;

namespace Net.Lab.DAL.Repositories.Interfaces
{
    public interface IReviewsRepository
    {
        IEnumerable<Review> GetReviews();

        Review GetReview(int id);

        void CreateReview(Review review);

        void EditReview(int id, Review review);

        void DeleteReview(int id);
    }
}
