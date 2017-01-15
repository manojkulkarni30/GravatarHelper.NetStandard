using GravatarHelper.NetStandard.Models;
using GravatarHelper.NetStandard.Tests.DataSource;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GravatarHelper.NetStandard.Tests
{
    /// <summary>
    /// Test for Gravatar image url, retrieve gravatar profile and gravatar profile QR code image url functionality
    /// </summary>
    public class GravatarTests
    {
        #region Fields
        private const string TestEmailAddress = "FirstName.LASTNAME@example.com";

        private const int MinimumDefaultImageSize = 1;

        private const int MaximumDefaultImageSize = 2048;
        #endregion

        #region Utility Methods
        private Uri ConvertToUri(string str)
        {
            return new Uri(str);
        }

        private string GetQueryStringParameterValue(Uri uri, string parameterName)
        {
            if (uri != null && !string.IsNullOrWhiteSpace(uri.Query))
            {
                var queryStringParameters = uri.Query.Remove(0, 1).Split('&');
                foreach (var parameter in queryStringParameters)
                {
                    var keyValue = parameter.Split('=');
                    if (keyValue != null && keyValue.Any() && keyValue[0] == parameterName)
                    {
                        return keyValue[1];
                    }
                }
            }
            return string.Empty;
        }
        #endregion

        #region Tests
        [Theory(DisplayName = "Gravatar image url should be a valid url")]
        [MemberData(nameof(EmailAddressDataSource.TestEmailAddressAData), MemberType = typeof(EmailAddressDataSource))]
        public void GravatarImageUrlShouldBeAValidUrl(string emailAddress)
        {
            var uri = ConvertToUri(Gravatar.GetGravatarImageUrl(emailAddress));

            Assert.True(uri.IsWellFormedOriginalString());
        }

        [Theory(DisplayName = "Gravatar image url should be empty url for an empty or null email address")]
        [InlineData("")]
        [InlineData(null)]
        public void EmptyOrNullEmailAddressShouldReturnEmptyGravatarImageUrl(string emailAddress)
        {
            var gravatarImageUrl = Gravatar.GetGravatarImageUrl(emailAddress);

            Assert.True(gravatarImageUrl == string.Empty);
        }


        [Theory(DisplayName = "Gravatar image size should be in between default image size range")]
        [MemberData(nameof(ImageSizeDataSource.TestImageSizeAData), MemberType = typeof(ImageSizeDataSource))]
        public void ImageSizeShouldBeInDefaultImageSizeRange(int imageSize)
        {
            var uri = ConvertToUri(Gravatar.GetGravatarImageUrl(TestEmailAddress, imageSize));

            int actualImageSize = 0;
            int.TryParse(GetQueryStringParameterValue(uri, "s"), out actualImageSize);

            Assert.True(actualImageSize >= MinimumDefaultImageSize && actualImageSize <= MaximumDefaultImageSize);
        }


        [Theory(DisplayName = "Gravatar image url should be returned with requested image extension")]
        [InlineData(ImageExtension.JPG)]
        [InlineData(ImageExtension.GIF)]
        [InlineData(ImageExtension.PNG)]
        public void GravatarImageUrlShouldBeReturnedWithRequestedImageExtension(ImageExtension imageExtension)
        {
            var uri = ConvertToUri(Gravatar.GetGravatarImageUrl(TestEmailAddress, imageExtension: imageExtension));

            Assert.True(uri.AbsoluteUri.EndsWith(imageExtension.ToString().ToLower()));
        }

        [Theory(DisplayName = "Gravatar image url should be returned with requested gravatar image rating")]
        [InlineData(GravatarRating.PG)]
        [InlineData(GravatarRating.G)]
        [InlineData(GravatarRating.R)]
        [InlineData(GravatarRating.X)]
        public void GravatarImageUrlShouldBeReturnedWithRequestedGravatarImageRating(GravatarRating rating)
        {
            var uri = ConvertToUri(Gravatar.GetGravatarImageUrl(TestEmailAddress, rating: rating));

            var actualRatingValue = GetQueryStringParameterValue(uri, "r");

            Assert.Equal(rating.ToString().ToLower(), actualRatingValue);
        }


        [Theory(DisplayName = "Gravatar image url should be returned with requested gravatar default image type")]
        [InlineData(GravatarDefaultImageType.Blank, "blank")]
        [InlineData(GravatarDefaultImageType.Identicon, "identicon")]
        [InlineData(GravatarDefaultImageType.Image404, "404")]
        [InlineData(GravatarDefaultImageType.MM, "mm")]
        [InlineData(GravatarDefaultImageType.MonsterId, "monsterid")]
        [InlineData(GravatarDefaultImageType.Retro, "retro")]
        [InlineData(GravatarDefaultImageType.Wavatar, "wavatar")]
        public void GravatarImageUrlShouldBeReturnedWithRequestedGravatarDefaultImageType(GravatarDefaultImageType gravatarDefaultImageType, string expectedGravatarDefaultImageType)
        {
            var uri = ConvertToUri(Gravatar.GetGravatarImageUrl(TestEmailAddress, gravatarDefaultImageType: gravatarDefaultImageType));

            var actualGravatarDefaultImageType = GetQueryStringParameterValue(uri, "d");

            Assert.Equal(expectedGravatarDefaultImageType, actualGravatarDefaultImageType);
        }

        [Fact(DisplayName = "Secure gravatar image url should be returned when requested")]
        public void SecureGravatarImageUrlShouldBeReturnedWhenRequested()
        {
            var uri = ConvertToUri(Gravatar.GetSecureGravatarImageUrl(TestEmailAddress));

            Assert.True(uri.Scheme == "https" && "secure.gravatar.com" == uri.Host);
        }

        [Theory(DisplayName = "Gravatar image url should be returned with all the requested information")]
        [MemberData(nameof(GravatarImageUrlParameterDataSource.TestGravatarImageUrlParameterAData),
            MemberType = typeof(GravatarImageUrlParameterDataSource))]
        public void GravatarImageUrlShouldBeReturnedWithAllRequestedInformation(string emailAddress,
            string expectedResult,
            int imageSize,
            ImageExtension? imageExtension,
            GravatarRating? rating,
            GravatarDefaultImageType? gravatarDetaultImageType,
            string defaultImageUrl = "",
            bool forceDefaultImage = false)
        {
            var actualGravatarUrl = Gravatar.GetGravatarImageUrl(email: emailAddress,
                imageSize: imageSize,
                imageExtension: imageExtension,
                defaultImageUrl: defaultImageUrl,
                forceDefaultImage: forceDefaultImage,
                gravatarDefaultImageType: gravatarDetaultImageType,
                rating: rating);

            if (!string.IsNullOrWhiteSpace(actualGravatarUrl) && !string.IsNullOrWhiteSpace(expectedResult))
                Assert.True(ConvertToUri(expectedResult).AbsoluteUri == ConvertToUri(actualGravatarUrl).AbsoluteUri);
            else
                Assert.Equal(expectedResult, actualGravatarUrl);
        }

        [Theory(DisplayName = "Gravatar profile information should return OperationResult object")]
        [MemberData(nameof(EmailAddressDataSource.TestEmailAddressAData),MemberType =typeof(EmailAddressDataSource))]
        public async Task GetGravatarProfileInformationAsyncShouldReturnOperationResultType(string emailAddress)
        {
            var profileInformation = await Gravatar.GetGravatarProfileInformationAsync(emailAddress);

            Assert.IsType(typeof(OperationResult), profileInformation);
        }

        [Theory(DisplayName = "Gravatar profile information should return Success field value to false if primary email is not provided")]
        [MemberData(nameof(EmailAddressDataSource.TestEmailAddressAData), MemberType = typeof(EmailAddressDataSource))]
        public async Task GetGravatarProfileInformationAsyncShouldReturnSuccessToFalseIfPrimaryEmailAddressIsNotProvided(string emailAddress)
        {
            var profileInformation = await Gravatar.GetGravatarProfileInformationAsync(emailAddress);

            Assert.False(profileInformation.Success);
        }

        [Theory(DisplayName = "Gravatar profile information should return null profile object if primary email is not provided")]
        [MemberData(nameof(EmailAddressDataSource.TestEmailAddressAData), MemberType = typeof(EmailAddressDataSource))]
        public async Task GetGravatarProfileInformationAsyncShouldReturnNullProfileIfPrimaryEmailAddressIsNotProvided(string emailAddress)
        {
            var profileInformation = await Gravatar.GetGravatarProfileInformationAsync(emailAddress);

            Assert.Null(profileInformation.Profile);
        }

        [Theory(DisplayName = "Gravatar profile QR code image url should be a valid url")]
        [MemberData(nameof(EmailAddressDataSource.TestEmailAddressAData), MemberType = typeof(EmailAddressDataSource))]
        public void GetGravatarProfileQrCodeImageShouldBeAValidUrl(string emailAddress)
        {
            var uri = ConvertToUri(Gravatar.GetGravatarImageUrl(emailAddress));

            Assert.True(uri.IsWellFormedOriginalString());
        }


        [Theory(DisplayName = "Gravatar profile QR code image url should be returned with all the requested information")]
        [MemberData(nameof(GravatarProfileQrCodeImageUrlParameterDataSource.TestGravatarProfileQrCodeImageUrlParameterAData),
            MemberType = typeof(GravatarProfileQrCodeImageUrlParameterDataSource))]
        public void GravatarProfileQrCodeImageUrlShouldBeReturnedWithAllRequestedInformation(string emailAddress,
            string expectedResult,
            int imageSize)
        {
            var actualGravatarProfileQrCodeImageUrl = Gravatar.GetGravatarProfileQrCodeImage(email: emailAddress,
                imageSize: imageSize);

            if (!string.IsNullOrWhiteSpace(actualGravatarProfileQrCodeImageUrl) && !string.IsNullOrWhiteSpace(expectedResult))
                Assert.True(ConvertToUri(expectedResult).AbsoluteUri == ConvertToUri(actualGravatarProfileQrCodeImageUrl).AbsoluteUri);
            else
                Assert.Equal(expectedResult, actualGravatarProfileQrCodeImageUrl);
        }

        [Theory(DisplayName = "Gravatar profile QR code image size should be in between default image size range")]
        [MemberData(nameof(ImageSizeDataSource.TestImageSizeAData), MemberType = typeof(ImageSizeDataSource))]
        public void GravatarProfileQrCodeImageSizeShouldBeInDefaultImageSizeRange(int imageSize)
        {
            var uri = ConvertToUri(Gravatar.GetGravatarProfileQrCodeImage(TestEmailAddress, imageSize));

            int actualImageSize = 0;
            int.TryParse(GetQueryStringParameterValue(uri, "s"), out actualImageSize);

            Assert.True(actualImageSize >= MinimumDefaultImageSize && actualImageSize <= MaximumDefaultImageSize);
        }
        #endregion
    }
}
