using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReviewSiteData.Base.Model;
using ReviewSiteLogic.Util;

namespace ReviewSiteTest {

    [TestCategory("Display Conversion")]
    [TestClass]
    public class DisplayConverterTest {
        private List<Review> reviews;
        private List<Restaurant> restaurants;
        private DateTime now;

        private DisplayConverter dsc;

        [TestInitialize]
        public void Initialize() {
            now = DateTime.Now;
            reviews = new List<Review>();
            restaurants = new List<Restaurant>();
            dsc = new DisplayConverter();

            reviews.Add(new Review() {
                Body = "body1",
                DatePublished = now,
                Id = 1,
                Name = "reviewer1",
                Rating = 5,
                RestaurantId = 1,
                Title = "title1"
            });

            reviews.Add(new Review() {
                Body = "body2",
                DatePublished = now,
                Id = 2,
                Name = "reviewer2",
                Rating = 10,
                RestaurantId = 1,
                Title = "title2"
            });

            reviews.Add(new Review() {
                Body = "body3",
                DatePublished = now,
                Id = 3,
                Name = "reviewer3",
                Rating = 5,
                RestaurantId = 2,
                Title = "title3"
            });

            reviews.Add(new Review() {
                Body = "body4",
                DatePublished = now,
                Id = 4,
                Name = "reviewer4",
                Rating = 10,
                RestaurantId = 2,
                Title = "title4"
            });

            restaurants.Add(new Restaurant() {
                Address = "1234 test ln",
                Id = 1,
                Name = "testaurant",
                Phone = "1234567890",
                Reviews = new List<Review>(reviews.GetRange(0, 2))
            });

            restaurants.Add(new Restaurant() {
                Address = "4321 test ave",
                Id = 2,
                Name = "testaurant2",
                Phone = "9876543210",
                Reviews = new List<Review>(reviews.GetRange(2, 2))
            });
        }

        [TestMethod]
        public void ReviewToDisplayAnon() {
            var r = new Review() {
                Name = "",
                Body = "",
                DatePublished = now,
                Id = 8,
                Rating = 4,
                RestaurantId = 1,
                Title = "Good"
            };

            var result = dsc.ToDisplay(r);

            Assert.AreEqual(r.Name, result.ReviewerName);
            Assert.AreEqual(r.DatePublished, result.DatePublished);
            Assert.AreEqual(r.Rating, result.Rating);
            Assert.AreEqual(r.Title, result.Title);
            Assert.AreEqual(r.Body, result.Body);
        }

        [TestMethod]
        public void ReviewToDisplay() {
            var r = new Review() {
                Name = "Reviewerman",
                Body = "",
                DatePublished = now,
                Id = 8,
                Rating = 4,
                RestaurantId = 1,
                Title = "Good"
            };

            var result = dsc.ToDisplay(r);

            Assert.AreEqual(r.Name, result.ReviewerName);
            Assert.AreEqual(r.DatePublished, result.DatePublished);
            Assert.AreEqual(r.Rating, result.Rating);
            Assert.AreEqual(r.Title, result.Title);
            Assert.AreEqual(r.Body, result.Body);
        }
    }

}