﻿using System.Security.Cryptography;
using System.Text;

namespace HotelsHubApp.Business.HttpRequests.Helper
{
    public static class Signature
    {
        public static string CreateSignature()
        {
            string signature;
            using (var sha = SHA256.Create())
            {
                long ts = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0,
                DateTimeKind.Utc)).TotalMilliseconds / 1000;
                Console.WriteLine("Timestamp: " + ts);
                var computedHash = sha.ComputeHash(Encoding.UTF8.GetBytes("b4036e737662995f3452af42bc59e114" + "be8c201059" + ts));
                signature = BitConverter.ToString(computedHash).Replace("-", "");
            }
            return signature;
        }
    }
}
