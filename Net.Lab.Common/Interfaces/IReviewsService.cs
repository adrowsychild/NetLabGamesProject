using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        Task<IEnumerable<Review>> GetReviewsAsync();

        Task<Review> GetReviewAsync(int reviewId);

        Task CreateReviewAsync(Review review);

        Task EditReviewAsync(int reviewId, Review review);

        Task DeleteReviewAsync(int reviewId);
    }
}
