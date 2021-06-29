namespace LibTwo
{
    public interface ICipherConverter
    {
        byte[] ConvertClearTextToBytes(string clearText);

        string ConvertEncryptedBytesToCipherText(byte[] encryptedBytes);

        byte[] ConvertCipherTextToBytes(string cipherText);

        string ConvertDecryptedBytesToClearText(byte[] decryptedBytes);

        byte[] ConvertSecretKeyToBytes(string secretKey);
    }
}
