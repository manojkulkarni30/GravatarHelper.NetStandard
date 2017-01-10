using Newtonsoft.Json;

namespace GravatarHelper.NetStandard.Models
{
    public class GravatarProfileModel
    {
        [JsonProperty(PropertyName ="entry")]
        public ProfileInformation[] ProfileInfo { get; set; }
    }
}
