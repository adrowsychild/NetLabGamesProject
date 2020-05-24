using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        Task<IEnumerable<Review>> GetReviewsAsync();

        Task<Review> GetReviewAsync(int id);

        Task CreateReviewAsync(Review review);

        Task EditReviewAsync(int id, Review review);

        Task DeleteReviewAsync(int id);
    }
}
