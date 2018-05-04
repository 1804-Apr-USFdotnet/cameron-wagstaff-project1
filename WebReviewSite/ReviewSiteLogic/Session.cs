using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using ReviewSiteData;
using ReviewSiteData.Persistence;
using ReviewSiteLogic.Render;
using ReviewSiteLogic.Util;

namespace ReviewSiteLogic {

    public class Session {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        private readonly WorkUnit _workUnit;
        private readonly DisplayConverter dsp;

        public Session(string name = "ReviewSiteContext") {
            try {
                _workUnit = new WorkUnit(new ReviewSiteContext(name));
            }
            catch (Exception e) {
                logger.Fatal(e.Message);
            }

            dsp = new DisplayConverter();
        }

        public List<RestaurantDisplay> ViewTopRestaurants() {
            var rests = dsp.ToDisplay(_workUnit.Restaurants.GetRestaurantsReviews());

            return rests.OrderByDescending(r => r.Rating).Take(3).ToList();
        }

        public List<RestaurantDisplay> ViewRestaurants() {
            return dsp.ToDisplay(_workUnit.Restaurants.GetRestaurantsReviews());
        }

        public List<RestaurantDisplay> ViewRestaurantsSortedNameAsc() {
            var rests = dsp.ToDisplay(_workUnit.Restaurants.GetRestaurantsReviews());

            return rests.OrderBy(r => r.Name).ToList();
        }

        public List<RestaurantDisplay> ViewRestaurantsSortedNameDesc() {
            var rests = dsp.ToDisplay(_workUnit.Restaurants.GetRestaurantsReviews());

            return rests.OrderByDescending(r => r.Name).ToList();
        }

        public List<RestaurantDisplay> ViewRestaurantsSortedRatingAsc() {
            var rests = dsp.ToDisplay(_workUnit.Restaurants.GetRestaurantsReviews());

            return rests.OrderBy(r => r.Rating).ToList();
        }

        public List<RestaurantDisplay> ViewRestaurantsSortedRatingDesc() {
            var rests = dsp.ToDisplay(_workUnit.Restaurants.GetRestaurantsReviews());

            return rests.OrderByDescending(r => r.Rating).ToList();
        }

        public List<RestaurantDisplay> SearchRestaurants(string term) {
            return dsp.ToDisplay(_workUnit.Restaurants.SearchRestaurants(term));
        }

        public List<RestaurantDisplay> SearchRestaurantsSortedNameAsc(string term) {
            var rests = dsp.ToDisplay(_workUnit.Restaurants.SearchRestaurants(term));

            return rests.OrderBy(r => r.Name).ToList();
        }

        public List<RestaurantDisplay> SearchRestaurantsSortedNameDesc(string term) {
            var rests = dsp.ToDisplay(_workUnit.Restaurants.SearchRestaurants(term));

            return rests.OrderByDescending(r => r.Name).ToList();
        }

        public List<RestaurantDisplay> SearchRestaurantsSortedRatingAsc(string term) {
            var rests = dsp.ToDisplay(_workUnit.Restaurants.SearchRestaurants(term));

            return rests.OrderBy(r => r.Rating).ToList();
        }

        public List<RestaurantDisplay> SearchRestaurantsSortedRatingDesc(string term) {
            var rests = dsp.ToDisplay(_workUnit.Restaurants.SearchRestaurants(term));

            return rests.OrderByDescending(r => r.Rating).ToList();
        }

        public RestaurantDisplay ViewRestaurant(int id) {
            return dsp.ToDisplay(_workUnit.Restaurants.GetRestaurantReviews(id));
        }

        public List<ReviewDisplay> ViewReviews(int id) {
            return dsp.ToDisplay(_workUnit.Reviews.GetReviews(id));
        }

        public void AddRestaurant(RestaurantDisplay rd) {
            try {
                _workUnit.Restaurants.Add(dsp.ToModel(rd));
                if (rd.Reviews != null) {
                    _workUnit.Reviews.Add(dsp.ToModel(rd.Reviews));
                }
                _workUnit.SaveChanges();
            }
            catch (Exception e) {
                logger.Error(e.Message);
            }
        }

        public void AddReview(ReviewDisplay rd) {
            try {
                _workUnit.Reviews.Add(dsp.ToModel(rd));
                _workUnit.SaveChanges();
            }
            catch (Exception e) {
                logger.Error(e.Message);
            }
        }

        public void UpdateRestaurant(RestaurantDisplay rd) {
            DeleteRestaurant(rd.Id);
            AddRestaurant(rd);
        }

        public void UpdateReview(ReviewDisplay rd) {
            DeleteReview(rd.Id);
            AddReview(rd);
        }

        public void DeleteRestaurant(int restId) {
            try {
                _workUnit.Restaurants.Remove(_workUnit.Restaurants.Get(restId));
                _workUnit.Reviews.Remove(_workUnit.Reviews.GetReviews(restId));
                _workUnit.SaveChanges();
            }
            catch (Exception e) {
                logger.Error(e.Message);
            }
        }

        public void DeleteReview(int reviewId) {
            try {
                _workUnit.Reviews.Remove(_workUnit.Reviews.Get(reviewId));
                _workUnit.SaveChanges();
            }
            catch (Exception e) {
                logger.Error(e.Message);
            }
        }
    }

}