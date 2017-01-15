using System.Collections.Generic;

namespace GravatarHelper.NetStandard.Tests.DataSource
{
    public static class HashDataSource
    {
        private static List<object[]> _data = 
            new List<object[]>
            {
                new object[] {"email@example.com", "5658ffccee7f0ebfda2b226238b1eb6e" },
                new object[] {"firstname.lastname@example.com", "56b4395848a1e9a46ceb39435ce77083"},
                new object[] {"1234567890@example.com", "59556d584ddf28283824ab6e9f1b3076"},
                new object[] {"email@subdomain.example.com", "a3619f89e4c0def6d252af9841d4e54f"},
                new object[] {"email@[123.123.123.123]", "efd01151ee232dad2ece0e0751d38540" },
                new object[] { "firstname+lastname@example.com", "cb54a6ce54eb6775acf743af06708ab5"},
                new object[] { "FirstName.LASTNAME@example.com", "3fa4b7e4cd263fab5fde2731924925b7" }
            };

        public static IEnumerable<object[]> TestHashAData
        {
            get { return _data; }
        }
    }
}
