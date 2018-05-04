using System;

namespace ReviewSiteLogic.Render {

    public class ReviewDisplay {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string ReviewerName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
        public DateTime DatePublished { get; set; }

        public ReviewDisplay() {
            DatePublished = DateTime.Now;
        }

        public ReviewDisplay(int id, int restaurantId, string reviewer, string title, string body, int rating, DateTime published) {
            Id = id;
            RestaurantId = restaurantId;
            ReviewerName = reviewer;
            Title = title;
            Body = body;
            Rating = rating;
            DatePublished = published;
        }

        public ReviewDisplay(int restaurantId, string reviewer, string title, string body, int rating) {
            RestaurantId = restaurantId;
            ReviewerName = reviewer;
            Title = title;
            Body = body;
            Rating = rating;
            DatePublished = DateTime.Now;
        }

        public override string ToString() {
            return $"\"{Title}\"\n" +
                   $"Rating: {Rating} / 10\n" +
                   (Body is null ? "" : $"\"{Body}\"\n") +
                   $"Left by {ReviewerName} on {DatePublished.ToShortDateString()}.\n";
        }
    }

}