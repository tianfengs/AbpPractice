using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace CryptorTools
{
    public static partial class Protector
    {
        public static string PublicKey;

        public static string GenerateSignature(string data)
        {
            byte[] dataBytes = Encoding.Unicode.GetBytes(data);
            var sha = SHA256.Create();
            var hashedData = sha.ComputeHash(dataBytes);

            var rsa = RSA.Create();
            PublicKey = rsa.ToXmlString(false); // exclude private key

            var signer = new RSAPKCS1SignatureFormatter(rsa);
            signer.SetHashAlgorithm("SHA256");

            return Convert.ToBase64String(signer.CreateSignature(hashedData));
        }

        public static bool ValidateSignature(string data, string signature)
        {
            byte[] dataBytes = Encoding.Unicode.GetBytes(data);
            var sha = SHA256.Create();
            var hashedData = sha.ComputeHash(dataBytes);

            byte[] signatureBytes = Convert.FromBase64String(signature);

            var rsa = RSA.Create();
            rsa.FromXmlString(PublicKey);

            var checker = new RSAPKCS1SignatureDeformatter(rsa);
            checker.SetHashAlgorithm("SHA256");

            return checker.VerifySignature(hashedData, signatureBytes);
        }
    }
}
