using System;
using ReviewSiteData.Base.Repo;

namespace ReviewSiteData.Base {

    public interface IWorkUnit : IDisposable {
        IRestaurantRepository Restaurants { get; }
        IReviewRepository Reviews { get; }
        int SaveChanges();
    }

}