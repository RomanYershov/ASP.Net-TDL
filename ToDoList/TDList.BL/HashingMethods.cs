using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TDList.BL
{
    public class HashingMethods
    {
        private const int defaoulSaltSize = 6;
        public static string CreateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[defaoulSaltSize];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public static string GenerateSha256Hash(string password, string salt)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var sgSha256Managed = new SHA256Managed();
            var hash = sgSha256Managed.ComputeHash(bytes);

            return ByteArrayToHexString(hash) + salt;
        }

        private static string ByteArrayToHexString(byte[] hash)
        {
            var hex = new StringBuilder(hash.Length * 2);
            foreach (var b in hash)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }
    }
}
