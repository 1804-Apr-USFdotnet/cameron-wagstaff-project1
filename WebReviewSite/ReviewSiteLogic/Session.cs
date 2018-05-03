using System;
using System.Collections.Generic;
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
            return dsp.ToDisplay(_workUnit.Restaurants.GetTopRestaurants(3));
        }

        public List<RestaurantDisplay> ViewRestaurants() {
            return dsp.ToDisplay(_workUnit.Restaurants.GetRestaurantsReviews());
        }

        public List<RestaurantDisplay> ViewRestaurantsSortedNameAsc() {
            return dsp.ToDisplay(_workUnit.Restaurants.GetRestaurantsReviewsSortedName(false));
        }

        public List<RestaurantDisplay> ViewRestaurantsSortedNameDesc() {
            return dsp.ToDisplay(_workUnit.Restaurants.GetRestaurantsReviewsSortedName(true));
        }

        public List<RestaurantDisplay> ViewRestaurantsSortedRatingAsc() {
            return dsp.ToDisplay(_workUnit.Restaurants.GetRestaurantsReviewsSortedRating(false));
        }

        public List<RestaurantDisplay> ViewRestaurantsSortedRatingDesc() {
            return dsp.ToDisplay(_workUnit.Restaurants.GetRestaurantsReviewsSortedRating(true));
        }

        public List<RestaurantDisplay> SearchRestaurants(string term) {
            return dsp.ToDisplay(_workUnit.Restaurants.SearchRestaurants(term));
        }

        public List<RestaurantDisplay> SearchRestaurantsSortedNameAsc(string term) {
            return dsp.ToDisplay(_workUnit.Restaurants.SearchRestaurantsSortedName(term, false));
        }

        public List<RestaurantDisplay> SearchRestaurantsSortedNameDesc(string term) {
            return dsp.ToDisplay(_workUnit.Restaurants.SearchRestaurantsSortedName(term, true));
        }

        public List<RestaurantDisplay> SearchRestaurantsSortedRatingAsc(string term) {
            return dsp.ToDisplay(_workUnit.Restaurants.SearchRestaurantsSortedRating(term, false));
        }

        public List<RestaurantDisplay> SearchRestaurantsSortedRatingDesc(string term) {
            return dsp.ToDisplay(_workUnit.Restaurants.SearchRestaurantsSortedRating(term, true));
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