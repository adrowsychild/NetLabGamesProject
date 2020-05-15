using Net.Lab.DataContracts.Reviews;
using System;
using System.Collections.Generic;
using System.Text;

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
