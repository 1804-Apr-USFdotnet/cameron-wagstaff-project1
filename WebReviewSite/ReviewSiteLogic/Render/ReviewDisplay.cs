namespace ReviewSiteLogic.Render {

    public class ReviewDisplay {
        public string ReviewerName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
        public string DatePublished { get; set; }

        public ReviewDisplay(string reviewer, string title, string body, int rating, string published) {
            ReviewerName = reviewer.Equals("") ? "Anonymous" : reviewer;
            Title = title;
            Body = body;
            Rating = rating;
            DatePublished = published;
        }

        public override string ToString() {
            return $"\"{Title}\"\n" +
                   $"Rating: {Rating} / 10\n" +
                   (Body is null ? "" : $"\"{Body}\"\n") +
                   $"Left by {ReviewerName} on {DatePublished}.\n";
        }
    }

}