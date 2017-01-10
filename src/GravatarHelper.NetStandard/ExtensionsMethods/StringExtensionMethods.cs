#if ( NETSTANDARD1_1 || NET35 || NET40 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462)
using System.Security.Cryptography;
#endif

#if (PORTABLE259)
using PCLCrypto;
#endif 

using System.Text;

namespace GravatarHelper.NetStandard.ExtensionsMethods
{
    /// <summary>
    /// Extension Methods for String
    /// </summary>
    public static class StringExtensionMethods
    {
        /// <summary>
        /// Get MD5 Hash of a string
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>MD5 Hash of input string</returns>
        public static string ToMd5Hash(this string str)
        {
            string hashValue = string.Empty;
            byte[] hash = null;
#if !(PORTABLE259)
            using (MD5 md5 = MD5.Create())
            {
                hash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            }
#else
            var hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Md5);
            byte[] inputBytes = Encoding.UTF8.GetBytes(str);
            hash = hasher.HashData(inputBytes);
#endif
            var sBuilder = new StringBuilder();

            if (hash != null)
            {
                for (int i = 0; i < hash.Length; i++)
                {
                    sBuilder.Append(hash[i].ToString("x2"));
                }
            }

            hashValue = sBuilder.ToString();

            return hashValue;
        }

    }
}
