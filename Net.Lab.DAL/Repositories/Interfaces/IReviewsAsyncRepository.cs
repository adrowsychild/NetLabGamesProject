using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Net.Lab.DataContracts.Reviews;

namespace Net.Lab.DAL.Repositories.Interfaces
{
    public interface IReviewsAsyncRepository
    {
        Task<IEnumerable<Review>> GetReviewsAsync();

        Task<Review> GetReviewAsync(int id);

        Task CreateReviewAsync(Review review);

        Task EditReviewAsync(int id, Review review);

        Task DeleteReviewAsync(int id);
    }
}
