using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ReviewSiteData.Base.Model;
using ReviewSiteData.Base.Repo;

namespace ReviewSiteData.Persistence.Repo {

    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository {
        public RestaurantRepository(DbContext context) : base(context) { }

        public ReviewSiteContext ReviewSiteContext => Context as ReviewSiteContext;

        public IEnumerable<Restaurant> GetTopRestaurants(int count) {
            return ReviewSiteContext.Restaurants
                .OrderByDescending(rest => rest.Reviews.Average(rev => rev.Rating)).Take(count).ToList();
        }

        public IEnumerable<Restaurant> GetRestaurantsReviews() {
            return ReviewSiteContext.Restaurants.ToList();
        }

        public Restaurant GetRestaurantReviews(int id) {
            return ReviewSiteContext.Restaurants.Single(rest => rest.Id == id);
        }

        public IEnumerable<Restaurant> SearchRestaurants(string term) {
            return ReviewSiteContext.Restaurants.Where(rest => rest.Name.Contains(term) || rest.Address.Contains(term))
                .ToList();
        }
    }

}