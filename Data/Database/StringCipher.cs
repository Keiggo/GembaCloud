using System.Security.Cryptography;
using System.Text;

namespace GembaCloud.PlaywrightTests.Data
{
    public static class StringCipher
    {
        // Determines the keysize of the encryption algorithm in bits.
        //private const int Keysize = 256;  // Incompatible with existing encrypted strings
        private const int Keysize = 128;

        // The number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;

        public static string Encrypt(string plainText, string passPhrase)
        {
            // Salt and IV is randomly generated each time and prepended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.
            var saltStringBytes = GenerateEntropy();
            var ivStringBytes = GenerateEntropy();

            // Create an Aes object with the specified key and IV,
            // create an encryptor to perform the stream transform.
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            using (Aes aesAlg = Aes.Create())
            using (var encryptor = aesAlg.CreateEncryptor(password.GetBytes(Keysize / 8), ivStringBytes))
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                using (var swEncrypt = new StreamWriter(csEncrypt, Encoding.UTF8))
                {
                    //Write all data to the stream.
                    swEncrypt.Write(plainText);
                }

                // Create the final bytes as a concatenation of, random salt bytes + random iv bytes + cipher bytes.
                var saltAndIvAndCipherTextBytes = saltStringBytes.Concat(ivStringBytes).Concat(msEncrypt.ToArray()).ToArray();
                return Convert.ToBase64String(saltAndIvAndCipherTextBytes);
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var saltAndIvAndCipherTextBytes = Convert.FromBase64String(cipherText);
            var saltStringBytes = saltAndIvAndCipherTextBytes.Take(Keysize / 8).ToArray();
            var ivStringBytes = saltAndIvAndCipherTextBytes.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            var cipherTextBytes = saltAndIvAndCipherTextBytes.Skip((Keysize / 8) * 2).ToArray();

            // Create an Aes object with the specified key and IV,
            // create a decryptor to perform the stream transform.
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            using (var aesAlg = Aes.Create())
            using (var decryptor = aesAlg.CreateDecryptor(password.GetBytes(Keysize / 8), ivStringBytes))
            using (var msDecrypt = new MemoryStream(cipherTextBytes))
            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            using (var srDecrypt = new StreamReader(csDecrypt, Encoding.UTF8))
            {
                // Return the decrypted bytes from the decrypting stream.
                return srDecrypt.ReadToEnd();
            }
        }

        private static byte[] GenerateEntropy()
        {
            var randomBytes = new byte[Keysize / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                // Fill the array with cryptographically secure random bytes.
                rng.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
}