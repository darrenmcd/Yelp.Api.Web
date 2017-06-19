using Newtonsoft.Json;

namespace Yelp.Api.Web.Models
{
    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
    }
}