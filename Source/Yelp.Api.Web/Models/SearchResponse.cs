using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yelp.Api.Web.Models
{
    public class SearchResponse : ResponseBase
    {
        [JsonProperty("region")]
        public Region Region { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("businesses")]
        public IList<BusinessResponse> Businesses { get; set; }
    }
}