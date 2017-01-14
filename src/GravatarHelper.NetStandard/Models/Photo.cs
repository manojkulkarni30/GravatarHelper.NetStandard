using Newtonsoft.Json;

namespace GravatarHelper.NetStandard.Models
{
    public class Photo
    {
        /// <summary>
        /// URL for an image
        /// </summary>
        [JsonProperty(PropertyName ="value")]
        public string Url { get; set; }

        /// <summary>
        /// Tyep of image (eg. Thumbnail)
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
