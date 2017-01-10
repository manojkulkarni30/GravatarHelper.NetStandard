using Newtonsoft.Json;

namespace GravatarHelper.NetStandard.Models
{
    public class Name
    {
        [JsonProperty(PropertyName = "givenName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "familyName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "formatted")]
        public string FullName { get; set; }
    }
}
