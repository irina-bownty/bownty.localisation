using Newtonsoft.Json;

namespace Bownty.LocalisationAPI.Request
{
    public class LocalisationResponse
    {
        [JsonProperty(PropertyName = "localised")]
        public string Localised { get; set; }
        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }
    }
}
