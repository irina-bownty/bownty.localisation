using Newtonsoft.Json;

namespace Bownty.LocalisationAPI.Request
{
    public class LocalisationRequest
    {
        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }
        [JsonProperty(PropertyName = "iso")]
        public string ISO { get; set; }
        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }
    }
}
