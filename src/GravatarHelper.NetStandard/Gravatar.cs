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
        private const string GravatarSecureBaseUrl = "https://www.gravatar.com";

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

        /// <summary>
        /// Default Image Size
        /// </summary>
        private const int DefaultImageSize = 80;

        /// <summary>
        /// Return 404 if image is not found with associated email hash
        /// </summary>
        private const string NotFoundImage = "404";

        /// <summary>
        /// Mystery Man Image
        /// </summary>
        private const string MysteryManImage = "mm";

        /// <summary>
        /// Identicon Image
        /// </summary>
        private const string IdenticonImage = "identicon";

        /// <summary>
        /// Monster Id Image
        /// </summary>
        private const string MonsterIdImage = "monsterid";

        /// <summary>
        /// Wavatar Image
        /// </summary>
        private const string WavatarImage = "wavatar";

        /// <summary>
        /// Retro Image
        /// </summary>
        private const string RetroImage = "retro";

        /// <summary>
        /// Blank Image
        /// </summary>
        private const string BlankImage = "blank";

        /// <summary>
        /// G Rating (Suitable for display on all websites with any audience type)
        /// </summary>
        private const string GRating = "g";

        /// <summary>
        /// pg Rating (May contain rude gestures, provocatively dressed individuals, the lesser swear words, or mild violence)
        /// </summary>
        private const string PgRating = "pg";

        /// <summary>
        /// r Rating (May contain such things as harsh profanity, intense violence, nudity, or hard drug use)
        /// </summary>
        private const string RRating = "r";

        /// <summary>
        /// x Rating (May contain hardcore sexual imagery or extremely disturbing violence.)
        /// </summary>
        private const string XRating = "x";
        #endregion

        #region Utility Methods
        /// <summary>
        /// Validate image size
        /// </summary>
        /// <param name="imageSize">Image size</param>
        /// <returns></returns>
        private static int ValidateImageSize(int imageSize)
        {
            if (imageSize == 0)
                imageSize = DefaultImageSize;

            imageSize = Math.Max(imageSize, MinImageSize);
            imageSize = Math.Min(imageSize, MaxImageSize);
            return imageSize;
        }

        /// <summary>
        /// Validate string content
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Boolean</returns>
        private static bool IsValidString(string str)
        {
#if (NET35)
            // https://msdn.microsoft.com/en-us/library/system.string.isnullorwhitespace.aspx
            return string.IsNullOrEmpty(str) || str.Trim().Length == 0;
#else
            return string.IsNullOrWhiteSpace(str);
#endif
        }

        /// <summary>
        /// Encode url
        /// </summary>
        /// <param name="str">URL</param>
        /// <returns></returns>
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
        /// get Gravatar Image URL
        /// </summary>
        /// <param name="email">Email Address</param>
        /// <param name="imageSize">Image Size. Default is 80</param>
        /// <param name="fileExtension">File Extension. Supported extensions are jpg, jpeg, gif and png.</param>
        /// <param name="defaultImageUrl">URL of default image to display if gravatar image is not found.</param>
        /// <param name="defaultImage">Default built in image to display if gravatar image is not found. Availabel options are 404, mm, identicon, monsterid, wavatar, retro and blank. Default is identicon.</param>
        /// <param name="forceDefaultImage">Force to display the default image. Default is false </param>
        /// <param name="rating">Rating of gravatar image. Available options are g, pg, r or x. Default is g.</param>
        /// <param name="useSecureUrl">Use secure URL. Default is false</param>
        /// <returns>Gravatar Image URL</returns>
        public static string GetGravatarImageUrl(string email,
            int imageSize = 0,
            string fileExtension = "",
            string defaultImageUrl = "",
            string defaultImage = "",
            bool forceDefaultImage = false,
            string rating = GRating, bool useSecureUrl = false)
        {
            // Validate image size
            imageSize = ValidateImageSize(imageSize);

            var url = new StringBuilder();

            // Create URL with MD5 has of an email
            if (useSecureUrl)
                url.Append($"{GravatarSecureBaseUrl + GravatarImagePath}{email.ToMd5Hash()}");
            else
                url.Append($"{GravatarBaseUrl + GravatarImagePath}{email.ToMd5Hash()}");

            // Append file extension (Supported extensions are jpg, jpeg, gif, png)
            if (!IsValidString(fileExtension))
                url.Append($".{fileExtension}");

            // Append image size
            url.Append($"?s={imageSize}");

            // Append default image url
            // Default build in image is identicon
            if (!IsValidString(defaultImageUrl))
                url.Append($"&d={EncodeUrl(defaultImageUrl)}");

            else if (!IsValidString(defaultImage))
                url.Append($"&d={defaultImage}");

            else
                url.Append($"&d={IdenticonImage}");

            // Force to display the default image
            if (forceDefaultImage)
                url.Append("&f=y");

            // Append rating
            // Default rating is g
            if (!IsValidString(rating))
                url.Append($"&r={rating}");
            else
                url.Append($"&r={GRating}");

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

                    if (!IsValidString(result))
                    {
                        var deserializedResult = JsonConvert.DeserializeObject<GravatarProfileModel>(result);
                        if (deserializedResult != null && deserializedResult.ProfileInfo != null && deserializedResult.ProfileInfo.Any())
                        {
                            operationResult.GravatarProfileInformation = deserializedResult.ProfileInfo.FirstOrDefault();
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

                    if (!IsValidString(result))
                    {
                        var deserializedResult = JsonConvert.DeserializeObject<GravatarProfileModel>(result);
                        if (deserializedResult != null && deserializedResult.ProfileInfo != null && deserializedResult.ProfileInfo.Any())
                        {
                            operationResult.GravatarProfileInformation = deserializedResult.ProfileInfo.FirstOrDefault();
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
        /// Get Gravatar Profile QR Code Image. (This image contains a link to the profile page of the requested user)
        /// </summary>
        /// <param name="email">Email Address</param>
        /// <param name="imageSize">Image Size. Default is 80</param>
        /// <param name="useSecureUrl">Use secure URL. Default is false</param>
        /// <returns>QR Code image for Gravatar Profile</returns>
        public static string GetGravatarProfileQrCodeImage(string email, int imageSize = 0,bool useSecureUrl=false)
        {
            imageSize = ValidateImageSize(imageSize);

            return $"{(useSecureUrl ? GravatarSecureBaseUrl : GravatarBaseUrl)}/{email.ToMd5Hash()}.qr?s={imageSize}";
        }
        #endregion
    }
}
