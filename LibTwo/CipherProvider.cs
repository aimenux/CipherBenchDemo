using Microsoft.Extensions.Options;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace LibTwo
{
    public sealed class CipherProvider : ICipherProvider
    {
        private readonly IBufferedCipher _encryptor;
        private readonly IBufferedCipher _decryptor;
        private readonly ICipherConverter _converter;

        public CipherProvider(ICipherConverter converter, IOptions<CipherConfiguration> configuration)
        {
            _converter = converter;
            _encryptor = GetCipher(configuration, CipherType.ForEncryption);
            _decryptor = GetCipher(configuration, CipherType.ForDecryption);
        }

        public string Encrypt(string clearText)
        {
            var textBytes = _converter.FromTextString(clearText);
            var encryptedBytes = _encryptor.DoFinal(textBytes);
            return _converter.ToHexString(encryptedBytes);
        }

        public string Decrypt(string cipherText)
        {
            var cipherBytes = _converter.FromHexString(cipherText);
            var decryptedBytes = _decryptor.DoFinal(cipherBytes);
            return _converter.ToTextString(decryptedBytes);
        }

        private IBufferedCipher GetCipher(IOptions<CipherConfiguration> configuration, CipherType cipherType)
        {
            var algorithm = GetAlgorithm();
            var key = configuration.Value.Key;
            var keyBytes = _converter.FromHexString(key);
            var cipher = CipherUtilities.GetCipher(algorithm);
            var forEncryption = cipherType == CipherType.ForEncryption;
            cipher.Init(forEncryption, new KeyParameter(keyBytes));
            return cipher;
        }

        private static string GetAlgorithm()
        {
            return $"AES/{CipherConfiguration.Mode}/{CipherConfiguration.Padding}Padding";
        }

        private enum CipherType
        {
            ForEncryption,
            ForDecryption
        }
    }
}