using Newtonsoft.Json;

namespace Yelp.Api.Web.Models
{
    public interface ICoordinates
    {
        double Latitude { get; set; }
        double Longitude { get; set; }
    }

    public class Coordinates : ICoordinates
    {
        public Coordinates()
        {
            Latitude = double.NaN;
            Longitude = double.NaN;
        }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}