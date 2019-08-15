using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Haosen.Common.Security
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2019/8/15 14:41:44
    /// 描述：AES加密/解密工具类
    /// </summary>
    public class AESHelper
    {
        #region CBC加密模式，NoPadding偏移
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="returnNull">加密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>密文</returns>
        public static string EncryptByCBC(string plainText, string key, string iv = "abcdefgh12345678", bool returnNull = false)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            string encrypt = null;
            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(keyBytes, ivBytes), CryptoStreamMode.Write))
                    {
                        cStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cStream.FlushFinalBlock();
                        encrypt = Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch { }
            aes.Clear();

            return returnNull ? encrypt : (encrypt == null ? string.Empty : encrypt);
        }

        /// <summary>
        /// AES解密，CBC模式
        /// </summary>
        /// <param name="encryptedText">密文字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="returnNull">解密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>明文</returns>
        public static string DecryptByCBC(string encryptedText, string key, string iv = "abcdefgh12345678", bool returnNull = false)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);

            string decrypt = null;
            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(keyBytes, ivBytes), CryptoStreamMode.Write))
                    {
                        cStream.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
                        cStream.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(mStream.ToArray()).TrimEnd(new char[] { '\0' });
                    }
                }
            }
            catch { }
            aes.Clear();

            return returnNull ? decrypt : (decrypt == null ? string.Empty : decrypt);
        }
        #endregion

        #region EBC加密模式，PKCS7Padding偏移
        /// <summary>
        /// AES加密，EBC模式
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="returnNull">解密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>密文</returns>
        public static string EncryptByEBC(string plainText, string key, string iv = "abcdefgh12345678", bool returnNull = false)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            string encrypt = null;
            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;

            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(keyBytes, ivBytes), CryptoStreamMode.Write))
                    {
                        cStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cStream.FlushFinalBlock();
                        encrypt = Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch { }
            aes.Clear();

            return returnNull ? encrypt : (encrypt == null ? string.Empty : encrypt);
        }

        /// <summary>
        /// AES解密，EBC模式
        /// </summary>
        /// <param name="encryptedText">密文字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="returnNull">解密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>明文</returns>
        public static string DecryptByEBC(string encryptedText, string key, string iv = "abcdefgh12345678", bool returnNull = false)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);

            string decrypt = null;
            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;

            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(keyBytes, ivBytes), CryptoStreamMode.Write))
                    {
                        cStream.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
                        cStream.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(mStream.ToArray()).TrimEnd(new char[] { '\0' });
                    }
                }
            }
            catch { }
            aes.Clear();

            return returnNull ? decrypt : (decrypt == null ? string.Empty : decrypt);
        }
        #endregion
    }
}
