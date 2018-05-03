using System.Collections.Generic;
using System.Linq;
using ReviewSiteData.Base.Model;
using ReviewSiteLogic.Render;

namespace ReviewSiteLogic.Util {

    public class DisplayConverter {
        public RestaurantDisplay ToDisplay(Restaurant r) {
            var rDisplay =
                new RestaurantDisplay(r.Id, r.Name, r.Address, r.Phone, r.Rating()) {
                    Reviews = ToDisplay(r.Reviews.ToList())
                };
            return rDisplay;
        }

        public ReviewDisplay ToDisplay(Review r) {
            return new ReviewDisplay(r.Id, r.RestaurantId, r.Name, r.Title, r.Body, r.Rating, r.DatePublished);
        }

        public List<RestaurantDisplay> ToDisplay(IEnumerable<Restaurant> r) {
            var restaurants = new List<RestaurantDisplay>();
            foreach (var restaurant in r) restaurants.Add(ToDisplay(restaurant));

            return restaurants;
        }

        public List<ReviewDisplay> ToDisplay(IEnumerable<Review> r) {
            var reviews = new List<ReviewDisplay>();
            foreach (var review in r) reviews.Add(ToDisplay(review));

            return reviews;
        }

        public Restaurant ToModel(RestaurantDisplay r) {
            List<Review> convertedReviews = new List<Review>();
            foreach (var review in r.Reviews) {
                convertedReviews.Add(ToModel(review));
            }

            return new Restaurant() {
                Name = r.Name,
                Address = r.Address,
                Phone = r.Phone,
                Reviews = convertedReviews,
                Id = r.Id
            };
        }

        public Review ToModel(ReviewDisplay r) {
            return new Review() {
                Rating = r.Rating,
                Body = r.Body,
                Name = r.ReviewerName,
                Title = r.Title,
                Id = r.Id,
                RestaurantId = r.RestaurantId,
                DatePublished = r.DatePublished
            };
        }

        public List<Review> ToModel(IEnumerable<ReviewDisplay> r) {
            var reviews = new List<Review>();
            foreach (var review in r) {
                reviews.Add(ToModel(review));
            }

            return reviews;
        }
    }

}