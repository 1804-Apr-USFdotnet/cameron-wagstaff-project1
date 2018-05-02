using System.Linq;
using ReviewSiteData.Base.Model;

namespace ReviewSiteLogic.Util {

    public static class RestaurantRating {
        public static double Rating(this Restaurant restaurant) {
            return restaurant.Reviews.Average(review => review.Rating);
        }
    }

}