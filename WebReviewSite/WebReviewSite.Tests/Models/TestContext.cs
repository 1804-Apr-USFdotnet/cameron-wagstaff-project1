using System.Collections.Generic;
using System.Data.Entity;
using ReviewSiteData.Base.Model;

namespace WebReviewSite.Tests.Models
{
    public class TestContext : DbContext {
        public static List<Restaurant> Restaurants = new List<Restaurant>() {
            new Restaurant() {

            }
        };

        public static List<Review> Reviews = new List<Review>() {
            new Review() {

            }
        };

        public new int SaveChanges() {
            
            return 1;
        }


    }
}
