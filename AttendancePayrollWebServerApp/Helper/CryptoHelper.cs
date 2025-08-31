using System;
using System.Security.Cryptography;
using System.Text;
public static class CryptoHelper
{
    public static string AES_Encrypt(string input, string pass)
    {
        using (var aes = Aes.Create())
        using (var sha256 = SHA256.Create())
        {
            string encrypted = "";
            try
            {
                byte[] keyBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
                aes.GenerateIV();

                aes.Key = keyBytes;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var encryptor = aes.CreateEncryptor())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                    byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                    byte[] result = new byte[aes.IV.Length + encryptedBytes.Length];
                    Array.Copy(aes.IV, 0, result, 0, aes.IV.Length);
                    Array.Copy(encryptedBytes, 0, result, aes.IV.Length, encryptedBytes.Length);

                    encrypted = Convert.ToBase64String(result);
                    return encrypted;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }





    public static string AES_Decrypt(string input, string pass)
    {
        using (var aes = Aes.Create())
        using (var sha256 = SHA256.Create())
        {
            string decrypted = "";
            try
            {
                byte[] keyBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
                byte[] fullCipher = Convert.FromBase64String(input);

                byte[] iv = new byte[aes.BlockSize / 8];
                byte[] cipher = new byte[fullCipher.Length - iv.Length];

                Array.Copy(fullCipher, 0, iv, 0, iv.Length);
                Array.Copy(fullCipher, iv.Length, cipher, 0, cipher.Length);

                aes.Key = keyBytes;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var decryptor = aes.CreateDecryptor())
                {
                    byte[] decryptedBytes = decryptor.TransformFinalBlock(cipher, 0, cipher.Length);
                    decrypted = Encoding.UTF8.GetString(decryptedBytes);
                    return decrypted;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}