using Net.Lab.DAL.Repositories.Interfaces;
using Net.Lab.DataContracts.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Net.Lab.DAL.Repositories.Implementations
{
    public class EFReviewsRepository : IReviewsRepository
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
    }
}
