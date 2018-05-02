using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ReviewSiteData.Base.Model;
using ReviewSiteData.Base.Repo;

namespace ReviewSiteData.Persistence.Repo {

    internal class ReviewRepository : Repository<Review>, IReviewRepository {
        public ReviewRepository(DbContext context) : base(context) { }

        public ReviewSiteContext ReviewSiteContext => Context as ReviewSiteContext;

        public IEnumerable<Review> GetReviews(int restaurantId) {
            return ReviewSiteContext.Reviews.Where(r => r.RestaurantId == restaurantId).ToList();
        }
    }

}