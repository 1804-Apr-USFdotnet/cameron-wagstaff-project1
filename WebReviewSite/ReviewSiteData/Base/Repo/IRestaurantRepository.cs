using System.Collections.Generic;
using ReviewSiteData.Base.Model;

namespace ReviewSiteData.Base.Repo {

    public interface IRestaurantRepository : IRepository<Restaurant> {
        IEnumerable<Restaurant> GetTopRestaurants(int count);
        IEnumerable<Restaurant> SearchRestaurants(string term);
        IEnumerable<Restaurant> GetRestaurantsReviews();
        Restaurant GetRestaurantReviews(int id);
    }

}