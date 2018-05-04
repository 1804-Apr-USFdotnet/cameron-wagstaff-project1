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
        public ActionResult ListRestaurants(string q, string sortBy) {
            if (sortBy == null) {
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
                    if (sortBy == "rd") {
                        return View(_session.ViewRestaurantsSortedRatingDesc());
                    }
                    if (sortBy == "ra") {
                        return View(_session.ViewRestaurantsSortedRatingAsc());
                    }
                    if (sortBy == "na") {
                        return View(_session.ViewRestaurantsSortedNameAsc());
                    }
                    if (sortBy == "nd") {
                        return View(_session.ViewRestaurantsSortedNameDesc());
                    }
                }
                else {
                    if (sortBy == "rd") {
                        return View(_session.SearchRestaurantsSortedRatingDesc(q));
                    }
                    if (sortBy == "ra") {
                        return View(_session.SearchRestaurantsSortedRatingAsc(q));
                    }
                    if (sortBy == "na") {
                        return View(_session.SearchRestaurantsSortedNameAsc(q));
                    }
                    if (sortBy == "nd") {
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

            _session.AddRestaurant(rd);
            return Redirect("/");
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