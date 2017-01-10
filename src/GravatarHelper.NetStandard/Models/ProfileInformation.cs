using Newtonsoft.Json;

namespace GravatarHelper.NetStandard.Models
{
    public class ProfileInformation
    {
        [JsonProperty(PropertyName ="id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "profileUrl")]
        public string ProfileUrl { get; set; }

        [JsonProperty(PropertyName = "preferredUsername")]
        public string PreferredUsername { get; set; }

        [JsonProperty(PropertyName = "thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty(PropertyName = "photos")]
        public Photo[] Photos { get; set; }

        [JsonProperty(PropertyName = "name")]
        public Name Name { get; set; }

        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "aboutMe")]
        public string AboutMe { get; set; }

        [JsonProperty(PropertyName = "urls")]
        public SocialLink[] SocialLinks { get; set; }
    }
}
