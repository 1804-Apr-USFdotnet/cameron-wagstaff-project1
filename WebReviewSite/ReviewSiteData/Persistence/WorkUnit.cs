using ReviewSiteData.Base;
using ReviewSiteData.Base.Repo;
using ReviewSiteData.Persistence.Repo;

namespace ReviewSiteData.Persistence {

    public class WorkUnit : IWorkUnit {
        private readonly ReviewSiteContext _context;

        public IRestaurantRepository Restaurants { get; private set; }
        public IReviewRepository Reviews { get; private set; }

        public WorkUnit(ReviewSiteContext context) {
            _context = context;
            Restaurants = new RestaurantRepository(_context);
            Reviews = new ReviewRepository(_context);
        }

        public int SaveChanges() {
            return _context.SaveChanges();
        }

        public void Dispose() {
            _context.Dispose();
        }
    }

}