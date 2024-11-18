using System.Security.Cryptography;
using System.Text;

public static class Cryptography
{
    public static string GetMd5Hash(string input)
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

    private static string? Decrypt(string cipherText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
    {
        if (string.IsNullOrEmpty(cipherText)) return null;

        var initVectorBytes = Encoding.ASCII.GetBytes(initVector);
        var saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
        var cipherTextBytes = Convert.FromBase64String(cipherText);
        var password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

        byte[] keyBytes = password.GetBytes(keySize / 8);
#pragma warning disable SYSLIB0022 // Type or member is obsolete
        using var symmetricKey = new RijndaelManaged { Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 };
#pragma warning restore SYSLIB0022 // Type or member is obsolete
        using var memoryStream = new MemoryStream(cipherTextBytes);
        using var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
        using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

        using StreamReader srDecrypt = new(cryptoStream);
        return srDecrypt.ReadToEnd();


    }


    private static string? Encrypt(string plainText,
                                string passPhrase,
                                string saltValue,
                                string hashAlgorithm,
                                int passwordIterations,
                                string initVector,
                                int keySize)
    {
        if (string.IsNullOrEmpty(plainText))
            return null;
        // Convert strings into byte arrays.
        // Let us assume that strings only contain ASCII codes.
        // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
        // encoding.
        byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
        byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

        // Convert our plaintext into a byte array.
        // Let us assume that plaintext contains UTF8-encoded characters.
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

        // First, we must create a password, from which the key will be derived.
        // This password will be generated from the specified passphrase and 
        // salt value. The password will be created using the specified hash 
        // algorithm. Password creation can be done in several iterations.
        PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                        passPhrase,
                                                        saltValueBytes,
                                                        hashAlgorithm,
                                                        passwordIterations);

        // Use the password to generate pseudo-random bytes for the encryption
        // key. Specify the size of the key in bytes (instead of bits).
        byte[] keyBytes = password.GetBytes(keySize / 8);

        // Create uninitialized Rijndael encryption object.
#pragma warning disable SYSLIB0022 // Type or member is obsolete
        var symmetricKey = new RijndaelManaged
        {
            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            Mode = CipherMode.CBC
        };
#pragma warning restore SYSLIB0022 // Type or member is obsolete

        // Generate encryptor from the existing key bytes and initialization 
        // vector. Key size will be defined based on the number of the key 
        // bytes.
        ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                                                        keyBytes,
                                                        initVectorBytes);

        // Define memory stream which will be used to hold encrypted data.
        MemoryStream memoryStream = new MemoryStream();

        // Define cryptographic stream (always use Write mode for encryption).
        CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                    encryptor,
                                                    CryptoStreamMode.Write);
        // Start encrypting.
        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

        // Finish encrypting.
        cryptoStream.FlushFinalBlock();

        // Convert our encrypted data from a memory stream into a byte array.
        byte[] cipherTextBytes = memoryStream.ToArray();

        // Close both streams.
        memoryStream.Close();
        cryptoStream.Close();

        // Convert encrypted data into a base64-encoded string.
        string cipherText = Convert.ToBase64String(cipherTextBytes);

        // Return encrypted string.
        return cipherText;
    }

    public static string? Encrypt(string plainText)
    {
        string passPhrase = "*f1n4nc14l-c@d3x!";       // can be any string
        string saltValue = "~4mt4~";        // can be any string
        string hashAlgorithm = "SHA1";         // can be "MD5"
        int passwordIterations = 2;            // can be any number
        string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        int keySize = 256;                // can be 192 or 128
        return Encrypt(plainText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
    }

    public static string? Decrypt(string cipherText)
    {
        string passPhrase = "*f1n4nc14l-c@d3x!";       // can be any string
        string saltValue = "~4mt4~";        // can be any string
        string hashAlgorithm = "SHA1";         // can be "MD5"
        int passwordIterations = 2;            // can be any number
        string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        int keySize = 256;                // can be 192 or 128

        return Decrypt(cipherText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
    }
}