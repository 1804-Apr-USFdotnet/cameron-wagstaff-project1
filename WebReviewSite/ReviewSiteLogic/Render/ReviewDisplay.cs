using System;
using System.ComponentModel.DataAnnotations;

namespace ReviewSiteLogic.Render {

    public class ReviewDisplay {
        public int Id { get; set; }
        public int RestaurantId { get; set; }

        [Display(Name = "Your Name")]
        [StringLength(30, ErrorMessage = "Names must be 30 characters or shorter.")]
        public string ReviewerName { get; set; }

        [Required(ErrorMessage = "A title is required.")]
        [Display(Name = "Review Title")]
        [StringLength(30, ErrorMessage = "Review title must be 30 characters or shorter.")]
        public string Title { get; set; }

        [Display(Name = "Review Text")]
        [DataType(DataType.MultilineText)]
        [StringLength(200, ErrorMessage = "Review text must be 200 characters or shorter.")]
        public string Body { get; set; }

        [Display(Name = "Rating")]
        [Required(ErrorMessage = "Please leave a rating.")]
        [Range(1,10, ErrorMessage = "Rating must be a number between 1 and 10.")]
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