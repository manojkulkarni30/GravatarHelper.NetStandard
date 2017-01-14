namespace GravatarHelper.NetStandard.Models
{
    public class OperationResult
    {
        public bool Success { get; set; }

        public ProfileInformation Profile { get; set; }

        public string Error { get; set; }
    }
}
