using Newtonsoft.Json;

namespace GravatarHelper.NetStandard.Models
{
    public class SocialLink
    {
        /// <summary>
        /// Social Site Profile Link
        /// </summary>
        [JsonProperty(PropertyName ="value")]
        public string Url { get; set; }

        /// <summary>
        /// Social Site Name
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string SiteName { get; set; }
    }
}
