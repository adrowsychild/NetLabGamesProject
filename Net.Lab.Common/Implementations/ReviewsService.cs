using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Net.Lab.Common.Interfaces;
using Net.Lab.DAL.Repositories.Interfaces;
using Net.Lab.DataContracts.Reviews;

namespace Net.Lab.Common.Implementations
{
    public class ReviewsService : IReviewsService
    {
        private IReviewsRepository reviewsRepository;

        public ReviewsService(IReviewsRepository reviewsRepository)
        {
            this.reviewsRepository = reviewsRepository;
        }

        public IEnumerable<Review> GetReviews()
        {
            return this.reviewsRepository.GetReviews();
        }

        public Review GetReview(int id)
        {
            return this.reviewsRepository.GetReview(id);
        }

        public void CreateReview(Review review)
        {
            this.reviewsRepository.CreateReview(review);
        }

        public void EditReview(int id, Review review)
        {
            this.reviewsRepository.EditReview(id, review);
        }

        public void DeleteReview(int id)
        {
            this.reviewsRepository.DeleteReview(id);
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync()
        {
            return await this.reviewsRepository.GetReviewsAsync();
        }

        public async Task<Review> GetReviewAsync(int id)
        {
            return await this.reviewsRepository.GetReviewAsync(id);
        }

        public async Task CreateReviewAsync(Review review)
        {
            await this.reviewsRepository.CreateReviewAsync(review);
        }

        public async Task EditReviewAsync(int id, Review review)
        {
            await this.reviewsRepository.EditReviewAsync(id, review);
        }

        public async Task DeleteReviewAsync(int id)
        {
            await this.reviewsRepository.DeleteReviewAsync(id);
        }
    }
}
