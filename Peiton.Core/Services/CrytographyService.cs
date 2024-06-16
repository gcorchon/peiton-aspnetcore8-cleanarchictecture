namespace Peiton.Core.Services;


public interface ICryptographyService
{
    string GetMd5Hash(string input);
    string Encrypt(string plainText);
    string Decrypt(string cipherText);
}