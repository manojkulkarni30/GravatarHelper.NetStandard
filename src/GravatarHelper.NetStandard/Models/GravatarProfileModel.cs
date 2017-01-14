using Newtonsoft.Json;
using System.Collections.Generic;

namespace GravatarHelper.NetStandard.Models
{
    public class GravatarProfileModel
    {
        public GravatarProfileModel()
        {
            ProfileInfo = new List<ProfileInformation>();
        }

        [JsonProperty(PropertyName ="entry")]
        public List<ProfileInformation> ProfileInfo { get; set; }
    }
}
