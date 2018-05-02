using System;

namespace ReviewSiteData.Base.Model {

    public class Review {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
        public DateTime DatePublished { get; set; }
    }

}