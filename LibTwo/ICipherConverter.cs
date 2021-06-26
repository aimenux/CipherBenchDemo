namespace LibTwo
{
    public interface ICipherConverter
    {
        byte[] FromTextString(string textString);

        string ToTextString(byte[] hexBytes);

        byte[] FromHexString(string hexString);

        string ToHexString(byte[] hexBytes);
    }
}
