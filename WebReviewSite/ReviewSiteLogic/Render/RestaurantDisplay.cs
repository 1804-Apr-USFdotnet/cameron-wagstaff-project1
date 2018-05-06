using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReviewSiteLogic.Render {

    public class RestaurantDisplay {
        public int Id { get; set; }

        [Display(Name = "Restaurant Name")]
        [Required(ErrorMessage = "Restaurants must have a name.")]
        [StringLength(30, ErrorMessage = "Restaurant names must be 30 characters or shorter.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "An address must be specified.")]
        [StringLength(50, ErrorMessage = "Addresses must be 50 characters or shorter.")]
        public string Address { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "A phone number is required.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Must be a valid phone number.")]
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