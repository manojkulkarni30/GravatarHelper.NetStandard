using Newtonsoft.Json;

namespace GravatarHelper.NetStandard.Models
{
    public class Photo
    {
        [JsonProperty(PropertyName ="value")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
