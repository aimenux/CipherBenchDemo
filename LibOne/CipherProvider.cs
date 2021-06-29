using System;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;

namespace LibOne
{
    public sealed class CipherProvider : ICipherProvider, IDisposable
    {
        private readonly RijndaelManaged _cipher;
        private readonly ICipherConverter _converter;

        public CipherProvider(ICipherConverter converter, IOptions<CipherConfiguration> configuration)
        {
            _converter = converter;
            _cipher = GetCipher(configuration);
        }

        public string Encrypt(string clearText)
        {
            var textBytes = _converter.ConvertClearTextToBytes(clearText);
            using var encryptor = _cipher.CreateEncryptor();
            var encryptedBytes = encryptor.TransformFinalBlock(textBytes, 0, textBytes.Length);
            return _converter.ConvertEncryptedBytesToCipherText(encryptedBytes);
        }

        public string Decrypt(string cipherText)
        {
            var cipherBytes = _converter.ConvertCipherTextToBytes(cipherText);
            using var decryptor = _cipher.CreateDecryptor();
            var decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            return _converter.ConvertDecryptedBytesToClearText(decryptedBytes);
        }

        private RijndaelManaged GetCipher(IOptions<CipherConfiguration> configuration)
        {
            var key = configuration.Value.Key;
            var mode = CipherConfiguration.Mode;
            var padding = CipherConfiguration.Padding;
            var keyBytes = _converter.ConvertSecretKeyToBytes(key);
            var cipher = new RijndaelManaged
            {
                Mode = mode,
                Padding = padding,
                Key = keyBytes,
                IV = keyBytes
            };
            return cipher;
        }

        public void Dispose()
        {
            _cipher?.Dispose();
        }
    }
}