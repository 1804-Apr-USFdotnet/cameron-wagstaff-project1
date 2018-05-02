using Newtonsoft.Json;
using ReviewSiteData.Base.Model;

namespace ReviewSiteLogic.Serialization {

    public static class RestaurantSerializer {
        public static string Serialize(this Restaurant restaurant) {
            return JsonConvert.SerializeObject(restaurant);
        }
    }

}