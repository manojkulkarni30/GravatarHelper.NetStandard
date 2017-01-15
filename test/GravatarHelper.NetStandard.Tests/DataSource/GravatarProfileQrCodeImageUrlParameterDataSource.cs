using System.Collections.Generic;

namespace GravatarHelper.NetStandard.Tests.DataSource
{
    public class GravatarProfileQrCodeImageUrlParameterDataSource
    {
        private static List<object[]> _data =
           new List<object[]>
           {

            new object[] {"email@example.com",
                "http://www.gravatar.com/5658ffccee7f0ebfda2b226238b1eb6e.qr?s=200",
                200
            },

             new object[] {"firstname.lastname@example.com",
                "http://www.gravatar.com/56b4395848a1e9a46ceb39435ce77083.qr?s=500",
                500
                },


              new object[] {"1234567890@example.com",
                "http://www.gravatar.com/59556d584ddf28283824ab6e9f1b3076.qr",
                0
             },

              new object[] {"firstname+lastname@example.com",
                "http://www.gravatar.com/cb54a6ce54eb6775acf743af06708ab5.qr?s=800",
                800
             },

             new object[] {"FirstName.LASTNAME@example.com",
                "http://www.gravatar.com/56b4395848a1e9a46ceb39435ce77083.qr?s=600",
                600
            },

            new object[] {null,
                string.Empty,
                600
            },

            new object[] {string.Empty,
                string.Empty,
                600
            },

             new object[] {"                    ",
                string.Empty,
                600
            },
           };

        public static IEnumerable<object[]> TestGravatarProfileQrCodeImageUrlParameterAData
        {
            get { return _data; }
        }
    }
}
