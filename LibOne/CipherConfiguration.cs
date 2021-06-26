using System.Security.Cryptography;

namespace LibOne
{
    public class CipherConfiguration
    {
        public string Key { get; set; }

        public static CipherMode Mode => CipherMode.ECB;

        public static PaddingMode Padding => PaddingMode.PKCS7;
    }
}