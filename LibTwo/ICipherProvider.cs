namespace LibTwo
{
    public interface ICipherProvider
    {
        string Encrypt(string clearText);

        string Decrypt(string cipherText);
    }
}