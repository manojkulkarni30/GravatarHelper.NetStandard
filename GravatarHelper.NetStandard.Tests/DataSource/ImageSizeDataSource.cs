using System.Collections.Generic;

namespace GravatarHelper.NetStandard.Tests.DataSource
{
    public class ImageSizeDataSource
    {
        private static List<object[]> _imageSizeData =
              new List<object[]>
              {
                new object[] {-1},
                new object[] {-100},
                new object[] {-1000},
                new object[] {1500},
                new object[] {6000}
        };

        public static IEnumerable<object[]> TestImageSizeAData
        {
            get { return _imageSizeData; }
        }
        
    }
}
