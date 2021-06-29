using System;
using System.Linq;
using System.Text;

namespace LibOne
{
    public class CipherConverter : ICipherConverter
    {
        public byte[] ConvertClearTextToBytes(string clearText) => Encoding.UTF8.GetBytes(clearText);

        public string ConvertEncryptedBytesToCipherText(byte[] encryptedBytes) => BitConverter.ToString(encryptedBytes).Replace("-", "");

        public byte[] ConvertCipherTextToBytes(string cipherText) => ConvertHexStringToBytes(cipherText);

        public string ConvertDecryptedBytesToClearText(byte[] decryptedBytes) => Encoding.UTF8.GetString(decryptedBytes);

        public byte[] ConvertSecretKeyToBytes(string secretKey) => ConvertHexStringToBytes(secretKey);

        private static byte[] ConvertHexStringToBytes(string hexString)
        {
            return Enumerable.Range(0, hexString.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hexString.Substring(x, 2), 16))
                .ToArray();
        }
    }
}