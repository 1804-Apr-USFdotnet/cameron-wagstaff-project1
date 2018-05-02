using System.Data.Entity;
using ReviewSiteData.Base.Model;

namespace ReviewSiteData {

    public class ReviewSiteContext : DbContext {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public ReviewSiteContext(string name = "ReviewSiteContext") : base(string.Concat("name=", name)) { }
    }

}