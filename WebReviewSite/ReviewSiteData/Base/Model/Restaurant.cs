using System.Collections.Generic;

namespace ReviewSiteData.Base.Model {

    public class Restaurant {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        //todo make a calculated value for rating so that you don't have to calculate it when querying
    }

}