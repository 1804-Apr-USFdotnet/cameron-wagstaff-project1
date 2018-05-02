using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReviewSiteData.Base.Model;
using ReviewSiteLogic.Serialization;

namespace ReviewSiteTest {

    [TestCategory("Serialization")]
    [TestClass]
    public class SerializationTest {
        private List<Restaurant> restaurants;
        private List<Review> reviews;

        [TestInitialize]
        public void Init() {
            //todo use TestDataLoader to bring in data
            var now = DateTime.Now;
            restaurants = new List<Restaurant>();
            reviews = new List<Review>();

            reviews.Add(new Review() {
                Body = "Body",
                DatePublished = now,
                Id = 3,
                Name = "Testy",
                Rating = 5,
                RestaurantId = 1,
                Title = "Title"
            });
            restaurants.Add(new Restaurant() {
                Address = "123 Test LN",
                Id = 1,
                Name = "Tester",
                Phone = "123456",
                Reviews = new List<Review>(reviews.ToArray())
            });
        }

        [TestMethod]
        public void RestaurantWithReviewSerialization() {
            var serialized = restaurants[0].Serialize();

            var result = RestaurantDeserializer.Deserialize(serialized);

            Assert.AreEqual(restaurants[0].Address, result.Address);
            Assert.AreEqual(restaurants[0].Id, result.Id);
            Assert.AreEqual(restaurants[0].Name, result.Name);
            Assert.AreEqual(restaurants[0].Phone, result.Phone);
            Assert.AreEqual(restaurants[0].Reviews.ToString(), result.Reviews.ToString());
        }
    }

}