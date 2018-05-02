using System.Collections.Generic;
using ReviewSiteData.Base.Model;

namespace ReviewSiteData.Base.Repo {

    public interface IReviewRepository : IRepository<Review> {
        IEnumerable<Review> GetReviews(int restaurantId);
    }

}