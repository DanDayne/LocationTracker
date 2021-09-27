using System;
using System.Security.Cryptography;
using System.Text;

namespace LocationTracker.Helpers
{
    public static class PasswordHelper
    {
        private static readonly SHA256Managed Sha256Managed = new SHA256Managed();

        public static string ToHash(string input)
        {
            var data = Sha256Managed.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            foreach (var singleByte in data)
            {
                sBuilder.Append(singleByte.ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}