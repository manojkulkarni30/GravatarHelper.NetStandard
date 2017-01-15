using System.Collections.Generic;

namespace GravatarHelper.NetStandard.Tests.DataSource
{
    public static class GravatarImageUrlParameterDataSource
    {
        private static List<object[]> _data =
        new List<object[]>
        {

            new object[] {"email@example.com",
                "http://www.gravatar.com/avatar/5658ffccee7f0ebfda2b226238b1eb6e.jpg?s=200&d=monsterid&r=pg",
                200,
                ImageExtension.JPG,
                GravatarRating.PG,
                GravatarDefaultImageType.MonsterId,
                string.Empty,
                false
            },

             new object[] {"firstname.lastname@example.com",
                "http://www.gravatar.com/avatar/56b4395848a1e9a46ceb39435ce77083.gif?s=500&d=identicon&f=y&r=g",
                500,
                ImageExtension.GIF,
                GravatarRating.G,
                GravatarDefaultImageType.Identicon,
                string.Empty,
                true,
                },


              new object[] {"1234567890@example.com",
                "http://www.gravatar.com/avatar/59556d584ddf28283824ab6e9f1b3076",
                0,
                null,
                null,
                null,
                string.Empty,
                false,
             },

              new object[] {"firstname+lastname@example.com",
                "http://www.gravatar.com/avatar/cb54a6ce54eb6775acf743af06708ab5.png?s=800&r=x",
                800,
                ImageExtension.PNG,
                GravatarRating.X,
                null,
                string.Empty,
                false,
             },

             new object[] {"FirstName.LASTNAME@example.com",
                "http://www.gravatar.com/avatar/56b4395848a1e9a46ceb39435ce77083?s=600&f=y",
                600,
                null,
                null,
                null,
                string.Empty,
                true,
            },

            new object[] {null,
                string.Empty,
                600,
                null,
                null,
                null,
                string.Empty,
                true,
            },

            new object[] {string.Empty,
                string.Empty,
                600,
                null,
                null,
                null,
                string.Empty,
                true,
            },

             new object[] {"                    ",
                string.Empty,
                600,
                null,
                null,
                null,
                string.Empty,
                true,
            },
        };

        public static IEnumerable<object[]> TestGravatarImageUrlParameterAData
        {
            get { return _data; }
        }
    }
}
