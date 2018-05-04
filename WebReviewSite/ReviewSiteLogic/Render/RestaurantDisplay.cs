using System.Collections.Generic;

namespace ReviewSiteLogic.Render {

    public class RestaurantDisplay {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double Rating { get; set; }

        public List<ReviewDisplay> Reviews { get; set; }

        public RestaurantDisplay(){}

        public RestaurantDisplay(int id, string name, string address, string phone, double rating) {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Rating = rating;
        }

        public override string ToString() {
            return $"({Id}) {Name}\n" +
                   $"Rating: {Rating.ToString("N1")} / 10\n" +
                   $"Address: {Address}\n" +
                   $"Phone: {Phone}\n";
        }
    }

}