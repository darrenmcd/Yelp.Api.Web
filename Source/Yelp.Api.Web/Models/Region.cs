using Newtonsoft.Json;

namespace Yelp.Api.Web.Models
{
    public class Region
    {
        [JsonProperty("center")]
        public Coordinates Center { get; set; }
    }
}