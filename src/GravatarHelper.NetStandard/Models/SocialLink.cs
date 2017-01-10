using Newtonsoft.Json;

namespace GravatarHelper.NetStandard.Models
{
    public class SocialLink
    {
        [JsonProperty(PropertyName ="value")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string SiteName { get; set; }
    }
}
