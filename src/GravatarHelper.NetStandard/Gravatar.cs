using GravatarHelper.NetStandard.ExtensionsMethods;
using GravatarHelper.NetStandard.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;

#if !(NET40 || NET35)
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
#endif

#if (NET35)
using System.Web;
#endif

using System.Text;

namespace GravatarHelper.NetStandard
{
    /// <summary>
    /// Gravatar Helper
    /// </summary>
    public static class Gravatar
    {
        #region Default Constant
        /// <summary>
        /// Gravatar Base URL
        /// </summary>
        private const string GravatarBaseUrl = "http://www.gravatar.com";

        /// <summary>
        /// Gravatar Secure Base URL
        /// </summary>
        private const string GravatarSecureBaseUrl = "https://secure.gravatar.com";

        /// <summary>
        /// Gravatar Profile Base Url
        /// </summary>
        private const string GravatarProfileBaseUrl = "https://en.gravatar.com/";

        /// <summary>
        /// Gravatar Image Path
        /// </summary>
        private const string GravatarImagePath = "/avatar/";

        /// <summary>
        /// Max Image Size
        /// </summary>
        private const int MaxImageSize = 2048;

        /// <summary>
        /// Min Image Size
        /// </summary>
        private const int MinImageSize = 1;

        #endregion

        #region Utility Methods
        /// <summary>
        /// Validate image size
        /// </summary>
        /// <param name="imageSize">Image size</param>
        /// <returns></returns>
        private static int ValidateImageSize(int imageSize)
        {
            imageSize = Math.Max(imageSize, MinImageSize);
            imageSize = Math.Min(imageSize, MaxImageSize);
            return imageSize;
        }

        /// <summary>
        /// Validate string
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Boolean</returns>
        private static bool IsNullOrWhiteSpace(string str)
        {
#if (NET35)
            // https://msdn.microsoft.com/en-us/library/system.string.isnullorwhitespace.aspx
            return string.IsNullOrEmpty(str) || str.Trim().Length == 0;
#else
            return string.IsNullOrWhiteSpace(str);
#endif
        }

        /// <summary>
        /// Encode String Content
        /// </summary>
        /// <param name="str">String Input</param>
        /// <returns>Encoded String</returns>
        private static string EncodeUrl(string str)
        {
#if (NET35)
            return HttpUtility.HtmlEncode(str);
#else
            return WebUtility.HtmlEncode(str);
#endif
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get Gravatar Image URL
        /// </summary>
        /// <param name="email">Email Address</param>
        /// <returns>Gravatar Image URL</returns>
        public static string GetGravatarImageUrl(string email)
        {
            return GetGravatarImageUrl(email,
                imageSize: 0,
                imageExtension: null,
                defaultImageUrl: string.Empty,
                forceDefaultImage: false,
                gravatarDefaultImageType: null,
                rating: null,
                useSecureUrl: false);
        }

        /// <summary>
        /// Get Secure Gravatar Image URL
        /// </summary>
        /// <param name="email">Email Address</param>
        /// <returns>Secure Gravatar Image URL</returns>
        public static string GetSecureGravatarImageUrl(string email)
        {
            return GetGravatarImageUrl(email,
                imageSize: 0,
                imageExtension: null,
                defaultImageUrl: string.Empty,
                forceDefaultImage: false,
                gravatarDefaultImageType: null,
                rating: null,
                useSecureUrl: true);
        }


        /// <summary>
        /// Get Gravatar Image Url
        /// </summary>
        /// <param name="email">Email Address</param>
        /// <param name="imageSize">Image Size</param>
        /// <returns>Gravatar Image URL</returns>
        public static string GetGravatarImageUrl(string email, int imageSize)
        {
            return GetGravatarImageUrl(email,
                imageSize: imageSize,
                imageExtension: null,
                defaultImageUrl: string.Empty,
                forceDefaultImage: false,
                gravatarDefaultImageType: null,
                rating: null,
                useSecureUrl: false);
        }


        /// <summary>
        /// Get Gravatar Image URL
        /// </summary>
        /// <param name="email">Email Address</param>
        /// <param name="imageSize">Image Size. Default is 80</param>
        /// <param name="imageExtension">Image Extension. Supported extensions are jpg, jpeg, gif and png.</param>
        /// <param name="defaultImageUrl">URL of custom default image to display if gravatar image is not found.</param>
        /// <param name="forceDefaultImage">Force to display custom default image. Default is false </param>
        /// <param name="gravatarDefaultImageType">Default gravatar image to display if gravatar image is not found. Availabel options are 404, mm, identicon, monsterid, wavatar, retro and blank. Default is identicon.</param>
        /// <param name="rating">Rating for gravatar image. Available options are g, pg, r or x. Default is g.</param>
        /// <param name="useSecureUrl">Use secure URL. Default is false</param>
        /// <returns>Gravatar Image URL</returns>
        public static string GetGravatarImageUrl(string email,
            int imageSize = 0,
            ImageExtension? imageExtension = null,
            string defaultImageUrl = "",
            bool forceDefaultImage = false,
            GravatarDefaultImageType? gravatarDefaultImageType = null,
            GravatarRating? rating = null, bool useSecureUrl = false)
        {
            var url = new StringBuilder();

            if (IsNullOrWhiteSpace(email))
                return string.Empty;

            // Remove leading and trailing whitespaces and force all characters to be lower case
            email = email.Trim();
            email = email.ToLower();

            // Create URL with MD5 has of an email
            if (useSecureUrl)
                url.Append($"{GravatarSecureBaseUrl + GravatarImagePath}{email.ToMd5Hash()}");
            else
                url.Append($"{GravatarBaseUrl + GravatarImagePath}{email.ToMd5Hash()}");

            // Image extension (Supported extensions are jpg, jpeg, gif, png)
            if (imageExtension != null)
                url.Append($".{imageExtension.ToString().ToLower()}");

            // Image size
            if (imageSize != 0)
            {
                // Validate image size
                imageSize = ValidateImageSize(imageSize);

                url.Append($"?s={imageSize}");
            }

            // Display custome default picture 
            if (!IsNullOrWhiteSpace(defaultImageUrl))
                url.Append($"&d={EncodeUrl(defaultImageUrl)}");

            // Display gravatar default image
            else if (gravatarDefaultImageType != null)
                url.Append($"&d={gravatarDefaultImageType.ToString().ToLower()}");

            // Force to display the default image
            if (forceDefaultImage)
                url.Append("&f=y");

            // Rating
            if (rating != null)
                url.Append($"&r={rating.ToString().ToLower()}");

            return url.ToString();
        }


#if !(NET40 || NET35)
        /// <summary>
        /// Get Gravatar Profile Information
        /// </summary>
        /// <param name="email">Email Address</param>
        /// <returns>Task</returns>
        public static async Task<OperationResult> GetProfileInformationAsync(string email)
        {
            var operationResult = new OperationResult();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GravatarProfileBaseUrl);
                    client.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Required to resolve the 403 forbidden error
                    client.DefaultRequestHeaders.Add("User-Agent", "User-Agent-Here");

                    string result = await client.GetStringAsync($"{email.ToMd5Hash()}.json");

                    if (!IsNullOrWhiteSpace(result))
                    {
                        var deserializedResult = JsonConvert.DeserializeObject<GravatarProfileModel>(result);
                        if (deserializedResult != null && deserializedResult.ProfileInfo != null && deserializedResult.ProfileInfo.Any())
                        {
                            operationResult.Profile = deserializedResult.ProfileInfo.FirstOrDefault();
                            operationResult.Success = true;
                        }
                    }
                }
                return operationResult;
            }
            catch (Exception ex)
            {
                operationResult.Error = ex.Message;
            }
            return operationResult;
        }

#else
        /// <summary>
        /// Get Gravatar Profile Information
        /// </summary>
        /// <param name="email">Email Address</param>
        /// <returns>Task</returns>
        public static OperationResult GetProfileInformation(string email)
        {
            var operationResult = new OperationResult();
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.UserAgent] = "User-Agent-Here";

                    string result = client.DownloadString($"{GravatarProfileBaseUrl + email.ToMd5Hash()}.json");

                    if (!IsNullOrWhiteSpace(result))
                    {
                        var deserializedResult = JsonConvert.DeserializeObject<GravatarProfileModel>(result);
                        if (deserializedResult != null && deserializedResult.ProfileInfo != null && deserializedResult.ProfileInfo.Any())
                        {
                            operationResult.Profile = deserializedResult.ProfileInfo.FirstOrDefault();
                            operationResult.Success = true;
                        }
                    }
                }
                return operationResult;
            }
            catch (Exception ex)
            {
                operationResult.Error = ex.Message;
            }
            return operationResult;
        }
#endif

        /// <summary>
        /// Get QR Code Image For Gravatar Profile
        /// </summary>
        /// <param name="email">Email Address</param>
        /// <param name="imageSize">Image Size. Default is 80</param>
        /// <param name="useSecureUrl">Use secure URL. Default is false</param>
        /// <returns>QR Code Image For Gravatar Profile</returns>
        public static string GetGravatarProfileQrCodeImage(string email, int imageSize = 0, bool useSecureUrl = false)
        {
            imageSize = ValidateImageSize(imageSize);

            return $"{(useSecureUrl ? GravatarSecureBaseUrl : GravatarBaseUrl)}/{email.ToMd5Hash()}.qr?s={imageSize}";
        }
        #endregion
    }
}
