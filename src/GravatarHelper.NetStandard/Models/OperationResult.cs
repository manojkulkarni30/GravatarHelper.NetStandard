namespace GravatarHelper.NetStandard.Models
{
    public class OperationResult
    {
        public bool Success { get; set; }

        public ProfileInformation GravatarProfileInformation { get; set; }

        public string Error { get; set; }
    }
}
