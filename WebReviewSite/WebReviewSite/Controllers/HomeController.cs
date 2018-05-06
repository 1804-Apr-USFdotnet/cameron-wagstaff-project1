using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReviewSiteLogic;
using System.Web.Mvc;
using ReviewSiteLogic.Render;

namespace WebReviewSite.Controllers
{
    public class HomeController : Controller {
        private readonly Session _session;

        public HomeController() {
            _session = new Session("TestReviewSiteContext");
        }

        public ActionResult Index() {
            var topRestaurants = _session.ViewTopRestaurants();
            return View(topRestaurants);
        }

        public ActionResult ListRestaurants() {
            var restaurantList = _session.ViewRestaurants();
            return View(restaurantList);
        }

        [HttpGet]
        public ActionResult ListRestaurants(string q, string sort) {
            if (sort == null) {
                if (q == null) {
                    return View(_session.ViewRestaurants());
                }
                else {
                    return View(_session.SearchRestaurants(q));
                }
            }
            else {
                if(q == null)
                {
                    if (sort == "rd") {
                        return View(_session.ViewRestaurantsSortedRatingDesc());
                    }
                    if (sort == "ra") {
                        return View(_session.ViewRestaurantsSortedRatingAsc());
                    }
                    if (sort == "na") {
                        return View(_session.ViewRestaurantsSortedNameAsc());
                    }
                    if (sort == "nd") {
                        return View(_session.ViewRestaurantsSortedNameDesc());
                    }
                }
                else {
                    if (sort == "rd") {
                        return View(_session.SearchRestaurantsSortedRatingDesc(q));
                    }
                    if (sort == "ra") {
                        return View(_session.SearchRestaurantsSortedRatingAsc(q));
                    }
                    if (sort == "na") {
                        return View(_session.SearchRestaurantsSortedNameAsc(q));
                    }
                    if (sort == "nd") {
                        return View(_session.SearchRestaurantsSortedNameDesc(q));
                    }
                }
                
            }

            return View(_session.ViewRestaurants());
        }

        public ActionResult ViewRestaurant(int id) {
            var restaurant = _session.ViewRestaurant(id);
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult CreateRestaurant() {
            var rd = new RestaurantDisplay();
            return View(rd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRestaurant(RestaurantDisplay rd) {
            if (ModelState.IsValid) {
                _session.AddRestaurant(rd);
            }
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult CreateReview(int id) {
            return View(new ReviewDisplay(){ RestaurantId = id });
        }

        [HttpPost]
        public ActionResult CreateReview(ReviewDisplay rd) {
            if (ModelState.IsValid) {
                _session.AddReview(rd);
            }
            return Redirect($"/Home/ViewRestaurant/{rd.RestaurantId}");
        }
        
        public ActionResult ManageRestaurant(int id) {
            return View(_session.ViewRestaurant(id));
        }

        [HttpGet]
        public ActionResult EditRestaurant(int id) {
            return View(_session.ViewRestaurant(id));
        }

        [HttpPost]
        public ActionResult EditRestaurant(RestaurantDisplay rd) {
            if (ModelState.IsValid) {
                _session.UpdateRestaurant(rd);
            }
            return Redirect("/Home/ListRestaurants");
        }

        [HttpGet]
        public ActionResult EditReview(int id) {
            return View(_session.GetReview(id));
        }

        [HttpPost]
        public ActionResult EditReview(ReviewDisplay rd) {
            if (ModelState.IsValid) {
                _session.UpdateReview(rd);
            }
            return Redirect($"/Home/ManageRestaurant/{rd.RestaurantId}");
        }

        public ActionResult DeleteRestaurant(int id) {
            _session.DeleteRestaurant(id);
            return Redirect("/Home/ListRestaurants");
        }

        public ActionResult DeleteReview(int id, int restaurantId) {
            _session.DeleteReview(id);
            return Redirect($"/Home/ManageRestaurant/{restaurantId}");
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}