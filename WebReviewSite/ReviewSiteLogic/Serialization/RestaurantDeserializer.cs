using System.Collections.Generic;
using Newtonsoft.Json;
using ReviewSiteData.Base.Model;

namespace ReviewSiteLogic.Serialization {

    public static class RestaurantDeserializer {
        public static Restaurant Deserialize(string json) {
            return JsonConvert.DeserializeObject<Restaurant>(json);
        }

        public static List<Restaurant> DeserializeList(string json) {
            return JsonConvert.DeserializeObject<List<Restaurant>>(json);
        }
    }

}