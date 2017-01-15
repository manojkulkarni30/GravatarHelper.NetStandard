using GravatarHelper.NetStandard.ExtensionsMethods;
using GravatarHelper.NetStandard.Tests.DataSource;
using Xunit;

namespace GravatarHelper.NetStandard.Tests
{
    /// <summary>
    /// Test for String Extension Methods
    /// </summary>
    public class StringExtensionMethodTests
    {
        /// <summary>
        /// Verify that ToMD5Hash extension method produces correct MD5 hash of provided input string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="expectedHashResult"></param>
        [Theory(DisplayName = "HashResult")]
        [MemberData(nameof(HashDataSource.TestHashAData),MemberType = typeof(HashDataSource))]
        public void HashResult(string str, string expectedHashResult)
        {
            var actualHashResult = str.ToMd5Hash();

            Assert.Equal(expectedHashResult, actualHashResult);
        }
    }
}
