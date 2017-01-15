using System.Collections.Generic;

namespace GravatarHelper.NetStandard.Tests.DataSource
{
    public class EmailAddressDataSource
    {
        private static List<object[]> _data =
            new List<object[]>
            {
                new object[] {"  email@example.com  "},
                new object[] {"FirstName.LASTNAME@example.com"},
                new object[] {"         1234567890@example.com"},
                new object[] {"email@subdomain.example.com"},
                new object[] {"email@[123.123.123.123]"},
                new object[] { "firstname+lastname@example.com"}
            };

        public static IEnumerable<object[]> TestEmailAddressAData
        {
            get { return _data; }
        }
    }
}
