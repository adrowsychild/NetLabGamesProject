using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Net.Lab.DAL.Repositories.Interfaces;
using Net.Lab.DataContracts.Reviews;

namespace Net.Lab.DAL.Repositories.Implementations
{
    public class EFReviewsRepository : IReviewsRepository, IReviewsAsyncRepository
    {
        private readonly ApplicationContext context;

        public EFReviewsRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Review> GetReviews()
        {
            return this.context.Reviews.ToArray();
        }

        public Review GetReview(int id)
        {
            return this.context.Reviews.Find(id);
        }
        
        public void CreateReview(Review review)
        {
            this.context.Reviews.Add(review);
            this.context.SaveChanges();
        }

        public void EditReview(int id, Review review)
        {
            var foundReview = GetReview(id);
            foundReview = (Review)Net.Lab.DAL.Helpers.ModelsChangeHelper.AssignObject(foundReview, review);
            this.context.SaveChanges();
        }

        public void DeleteReview(int id)
        {
            this.context.Reviews.Remove(GetReview(id));
            this.context.SaveChanges();
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync()
        {
            return await this.context.Reviews.ToArrayAsync();
        }

        public async Task<Review> GetReviewAsync(int id)
        {
            return await this.context.Reviews.FindAsync(id);
        }

        public async Task CreateReviewAsync(Review review)
        {
            await this.context.Reviews.AddAsync(review);
            await this.context.SaveChangesAsync();
        }

        public async Task EditReviewAsync(int id, Review review)
        {
            var foundReview = await GetReviewAsync(id);
            foundReview = (Review)Net.Lab.DAL.Helpers.ModelsChangeHelper.AssignObject(foundReview, review);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int id)
        {
            this.context.Reviews.Remove(await GetReviewAsync(id));
            await this.context.SaveChangesAsync();
        }
    }
}
