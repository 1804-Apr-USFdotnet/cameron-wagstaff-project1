using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReviewSiteLogic;
using System.Web.Mvc;

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
            var restaurantList = _session.ViewRestaurantsSortedRatingDesc();
            return View(restaurantList);
        }

        public ActionResult ViewRestaurant(int id) {
            var restaurant = _session.ViewRestaurant(id);
            return View(restaurant);
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