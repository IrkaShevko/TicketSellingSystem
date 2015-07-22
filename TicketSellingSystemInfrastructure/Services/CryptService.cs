using System;
using System.Security.Cryptography;
using System.Text;

namespace TicketSellingSystemInfrastructure.Services
{
    internal static class CryptService
    {
        internal static string GetMd5(string value)
        {
            var myPass = new MD5CryptoServiceProvider();
            var data = Encoding.ASCII.GetBytes(value);
            data = myPass.ComputeHash(data);
            return Encoding.ASCII.GetString(data);
        }

        internal static string GetRandomSalt()
        {
            var result = "";
            const string s = "ABCDEFGHIJKLMBOPQRSTUVWXYZ0123456789*/-+&?.,'";
            var rnd = new Random();
            var n = rnd.Next(10, 20);
            for (var i = 0; i < n; i++)
            {
                var next = s[rnd.Next(0, s.Length - 1)];
                if (rnd.NextDouble() < 0.5)
                    if (Char.IsLetter(next))
                        result += Char.ToLower(next);
                    else
                        result += next;
                else
                {
                    result += next;
                }
            }
            return result;
        }
    }
}