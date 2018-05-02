using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReviewSiteLogic;
using ReviewSiteLogic.Render;

namespace ReviewSiteTest {

    [TestCategory("Session Actions")]
    [TestClass]
    public class SessionTest {
        private Session session;

        [TestInitialize]
        public void Init() {
            session = new Session("TestReviewSiteContext");
        }

        [TestMethod]
        public void ViewSelectedRestaurant() {
            var result = session.ViewRestaurant(2);

            Assert.IsInstanceOfType(result, typeof(RestaurantDisplay));
            Assert.AreEqual("Denny's", result.Name);
            Assert.AreEqual("43371 Kingfisher Ave 33559", result.Address);
            Assert.AreEqual("2345678910", result.Phone);
            Assert.IsInstanceOfType(result.Reviews, typeof(List<ReviewDisplay>));
        }

        [TestMethod]
        public void ViewTopRestaurants() {
            var result = session.ViewTopRestaurants();

            Assert.IsInstanceOfType(result, typeof(List<RestaurantDisplay>));
        }

        [TestMethod]
        public void ViewAllRestaurants() {
            var result = session.ViewRestaurants();

            Assert.IsInstanceOfType(result, typeof(List<RestaurantDisplay>));
            Assert.AreEqual(25, result.Count);
        }

        [TestMethod]
        public void AddReview() {
            var reviewGuid = Guid.NewGuid().ToString();
            var rd = new ReviewDisplay("ReviewerName", "ReviewTitle", reviewGuid, 5, "");
            var restid = 1;

            session.AddReview(rd, restid);
            var result = session.ViewReviews(restid).Single(r => r.Body == reviewGuid);
            result.DatePublished = "";

            Assert.AreEqual(rd.ToString(), result.ToString());
        }
    }

}