using System.Linq;
using ReviewSiteData.Base.Model;

namespace ReviewSiteLogic.Util {

    public static class RestaurantRating {
        public static double Rating(this Restaurant restaurant) {
            if (restaurant.Reviews != null && restaurant.Reviews.Count > 0) {
                return restaurant.Reviews.Average(review => review.Rating);
            }
            else {
                return 0.0;
            }
        }
    }

}