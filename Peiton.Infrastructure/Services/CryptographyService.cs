using System.Security.Cryptography;
using System.Text;
using Peiton.DependencyInjection;

namespace Peiton.Core.Services;

[Injectable(typeof(ICryptographyService))]
public class CryptographyService : ICryptographyService
{
    public string GetMd5Hash(string input)
    {
        var sBuilder = new StringBuilder();
        using (var md5Hash = MD5.Create())
        {
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
        }

        return sBuilder.ToString();
    }

    
    private byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
    {
        // Check arguments.
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException("plainText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException("IV");
        byte[] encrypted;

        // Create an Aes object
        // with the specified key and IV.
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            // Create an encryptor to perform the stream transform.
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
        }

        // Return the encrypted bytes from the memory stream.
        return encrypted;
    }

    private string Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
    {
        // Check arguments.
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException("cipherText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException("IV");

        // Declare the string used to hold
        // the decrypted text.
        string? plaintext = null;

        // Create an Aes object
        // with the specified key and IV.
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            // Create a decryptor to perform the stream transform.
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {

                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        return plaintext;
    }
    
/*

    public string Encrypt(string plainText,
                      string passPhrase,
                      string saltValue,
                      string hashAlgorithm,
                      int passwordIterations,
                      string initVector,
                      int keySize)
    {
        byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
        byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

        using (var password = new Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations, new HashAlgorithmName(hashAlgorithm)))
        {
            byte[] keyBytes = password.GetBytes(keySize / 8);

            using (var symmetricKey = Aes.Create())
            {
                symmetricKey.Mode = CipherMode.CBC;

                using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                    }

                    byte[] cipherTextBytes = memoryStream.ToArray();
                    return Convert.ToBase64String(cipherTextBytes);
                }
            }
        }
    }



    public string Decrypt(string cipherText,
                      string passPhrase,
                      string saltValue,
                      string hashAlgorithm,
                      int passwordIterations,
                      string initVector,
                      int keySize)
    {
        byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
        byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
        byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

        using (var password = new Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations, new HashAlgorithmName(hashAlgorithm)))
        {
            byte[] keyBytes = password.GetBytes(keySize / 8);

            using (var symmetricKey = Aes.Create())
            {
                symmetricKey.Mode = CipherMode.CBC;

                using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                using (var memoryStream = new MemoryStream(cipherTextBytes))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                        int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                        return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                    }
                }
            }
        }
    }

    */

    public string Encrypt(string plainText)
    {
        string passPhrase = "*f1n4nc14l-c@d3x";       // can be any string
        string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        return Convert.ToBase64String(Encrypt(plainText, Encoding.ASCII.GetBytes(passPhrase), Encoding.ASCII.GetBytes(initVector)));
    }

    public string Decrypt(string cipherText)
    {
        string passPhrase = "*f1n4nc14l-c@d3x";       // can be any string
        string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        return Decrypt(Convert.FromBase64String(cipherText), Encoding.ASCII.GetBytes(passPhrase), Encoding.ASCII.GetBytes(initVector));
    }
}
