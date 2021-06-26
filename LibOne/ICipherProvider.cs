namespace LibOne
{
    public interface ICipherProvider
    {
        string Encrypt(string clearText);

        string Decrypt(string cipherText);
    }
}