using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
namespace Ch11_Exercise02
{
    public static class CryptorTool
    {
        //盐值字符序列最少8位，这里取16位
        private static readonly byte[] salts = Encoding.Unicode.GetBytes("netcore");
        //枚举次数最少1000，我们取2000
        private static readonly int iterations = 2000;

        public static string Encrypt(string clearText, string password)
        {
            byte[] plainBytes = Encoding.Unicode.GetBytes(clearText);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salts, iterations);
            var aes = Aes.Create();
            aes.IV = pbkdf2.GetBytes(16);
            aes.Key = pbkdf2.GetBytes(32);
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plainBytes, 0, plainBytes.Length);
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public static string Decrypt(string cryptoText,string password)
        {
            byte[] cryptoBytes= Convert.FromBase64String(cryptoText);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salts, iterations);
            var aes = Aes.Create();
            aes.IV = pbkdf2.GetBytes(16);
            aes.Key = pbkdf2.GetBytes(32);
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cryptoBytes, 0, cryptoBytes.Length);
                }
                return Encoding.Unicode.GetString(ms.ToArray());
            }
        }

        public static string GetSaltedHashedPwd(string password)
        {
            var rng = RandomNumberGenerator.Create();
            var saltedBytes = new byte[16];//16bit的盐值
            rng.GetBytes(saltedBytes);
            var saltText = Convert.ToBase64String(saltedBytes);

            var sha256 = SHA256.Create();
            var saltedPassword = saltText + password;
            var saltedHashedPwd = Convert.ToBase64String(sha256.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
            return saltedHashedPwd;
        }
    }
}
