using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReviewSiteData;
using ReviewSiteData.Base.Model;
using ReviewSiteData.Persistence;

namespace ReviewSiteTest {

    [TestCategory("Repo Actions")]
    [TestClass]
    public class RepoTest {
        private ReviewSiteContext reviewSiteContext;
        private WorkUnit workUnit;

        [TestInitialize]
        public void Init() {
            //todo mock EF instead of connecting to a test db
            reviewSiteContext = new ReviewSiteContext("TestReviewSiteContext");
            workUnit = new WorkUnit(reviewSiteContext);
        }

        [TestMethod]
        public void GetRestaurantTypeCorrect() {
            var restaurants = workUnit.Restaurants.Get();

            Assert.IsInstanceOfType(restaurants.First(), typeof(Restaurant));
        }

        [TestMethod]
        public void GetTopRestaurantTypeCorrect() {
            var restaurants = workUnit.Restaurants.GetTopRestaurants(3);

            Assert.IsInstanceOfType(restaurants.First(), typeof(Restaurant));
        }

        [TestMethod]
        public void GetRestaurantsWithReviewsTypeCorrect() {
            var restaurants = workUnit.Restaurants.GetRestaurantsReviews();

            Assert.IsInstanceOfType(restaurants.First().Reviews.First(), typeof(Review));
        }

        [TestMethod]
        public void GetReviewsForRestaurantTypeCorrect() {
            var reviews = workUnit.Reviews.GetReviews(2);

            Assert.IsInstanceOfType(reviews.First(), typeof(Review));
        }
    }

}