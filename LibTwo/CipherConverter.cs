using System;
using System.Linq;
using System.Text;

namespace LibTwo
{
    public class CipherConverter : ICipherConverter
    {
        public byte[] FromTextString(string textString) => Encoding.UTF8.GetBytes(textString);

        public string ToTextString(byte[] hexBytes) => Encoding.UTF8.GetString(hexBytes);

        public byte[] FromHexString(string hexString)
        {
            return Enumerable.Range(0, hexString.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hexString.Substring(x, 2), 16))
                .ToArray();
        }

        public string ToHexString(byte[] hexBytes)
        {
            return BitConverter.ToString(hexBytes).Replace("-", "");
        }
    }
}