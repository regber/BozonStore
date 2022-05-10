using System;
using System.Security.Cryptography;
using System.Text;

namespace BozonStore.Common
{
    public class StrToHashStr
    {
        public static string Hash(string str)
        {
            using (HashAlgorithm ag = SHA256.Create())
            {
                var hashString = ag.ComputeHash(Encoding.UTF8.GetBytes(str));
                return BitConverter.ToString(hashString);
            }
        }
    }
}
