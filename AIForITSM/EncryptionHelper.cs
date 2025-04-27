using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Provides helper methods for encrypting and decrypting strings using AES encryption.
/// </summary>
public static class EncryptionHelper
{
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("Your16ByteKey123"); // 16 bytes key
    private static readonly byte[] IV = new byte[16]; // Initialization vector (16 bytes)

    /// <summary>
    /// Encrypts a plain text string using AES encryption.
    /// </summary>
    /// <param name="plainText">The plain text to encrypt.</param>
    /// <returns>The encrypted string in Base64 format.</returns>
    public static string Encrypt(string plainText)
    {
        using Aes aes = Aes.Create();
        aes.Key = Key;
        aes.IV = IV;

        using ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using MemoryStream ms = new MemoryStream();
        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        {
            using (StreamWriter sw = new StreamWriter(cs))
            {
                sw.Write(plainText);
            }
        }

        return Convert.ToBase64String(ms.ToArray());
    }

    /// <summary>
    /// Decrypts a Base64-encoded string using AES encryption.
    /// </summary>
    /// <param name="cipherText">The encrypted string in Base64 format.</param>
    /// <returns>The decrypted plain text string.</returns>
    public static string Decrypt(string cipherText)
    {
        using Aes aes = Aes.Create();
        aes.Key = Key;
        aes.IV = IV;

        using ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText));
        using CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using StreamReader sr = new StreamReader(cs);
        return sr.ReadToEnd();
    }
}
