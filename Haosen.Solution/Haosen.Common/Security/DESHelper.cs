using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Haosen.Common.Security
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2019/8/15 14:41:54
    /// 描述：三重DES加密/解密工具类
    /// 普通的DES加密已不安全，与java可互通
    /// </summary>
    public class DESHelper
    {
        #region CBC加密模式，PKCS7Padding偏移（iv要参与运算，对应java的DESede/CBC/PKCS5Padding）
        /// <summary>
        /// DES加密，关于IV的说明：java中iv的长度等于8，CSharp可以为8的整数倍
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量，需要注意java的iv长度为8</param>
        /// <param name="returnNull">加密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>密文</returns>
        public static string EncryptByCBC(string plainText, string key, string iv = "abcdefgh", bool returnNull = false)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);            
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            string encrypt = null;
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Mode = CipherMode.CBC;
            des.Padding = PaddingMode.PKCS7;

            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, des.CreateEncryptor(keyBytes, ivBytes), CryptoStreamMode.Write))
                    {
                        cStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cStream.FlushFinalBlock();
                        encrypt = Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch { }
            des.Clear();

            return returnNull ? encrypt : (encrypt == null ? string.Empty : encrypt);
        }

        /// <summary>
        /// DES解密，关于IV的说明：java中iv的长度等于8，CSharp可以为8的整数倍
        /// </summary>
        /// <param name="encryptedText">密文字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量，需要注意java的iv长度为8</param>
        /// <param name="returnNull">解密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>明文</returns>
        public static string DecryptByCBC(string encryptedText, string key, string iv = "abcdefgh", bool returnNull = false)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);

            string decrypt = null;
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Mode = CipherMode.CBC;
            des.Padding = PaddingMode.PKCS7;

            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, des.CreateDecryptor(keyBytes, ivBytes), CryptoStreamMode.Write))
                    {
                        cStream.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
                        cStream.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(mStream.ToArray()).TrimEnd(new char[] { '\0' });
                    }
                }
            }
            catch { }
            des.Clear();

            return returnNull ? decrypt : (decrypt == null ? string.Empty : decrypt);
        }
        #endregion

        #region ECB加密模式，PKCS7Padding偏移（iv不参与运算，对应java的DESede/ECB/PKCS5Padding）

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量，iv不参与运算</param>
        /// <param name="returnNull">解密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>密文</returns>
        public static string EncryptByECB(string plainText, string key, string iv = "abcdefgh", bool returnNull = false)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            string encrypt = null;
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;

            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, des.CreateEncryptor(keyBytes, ivBytes), CryptoStreamMode.Write))
                    {
                        cStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cStream.FlushFinalBlock();
                        encrypt = Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch { }
            des.Clear();

            return returnNull ? encrypt : (encrypt == null ? string.Empty : encrypt);
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="encryptedText">密文字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量，iv不参与运算</param>
        /// <param name="returnNull">解密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>明文</returns>
        public static string DecryptByECB(string encryptedText, string key, string iv = "abcdefgh", bool returnNull = false)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);

            string decrypt = null;
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;

            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, des.CreateDecryptor(keyBytes, ivBytes), CryptoStreamMode.Write))
                    {
                        cStream.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
                        cStream.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(mStream.ToArray()).TrimEnd(new char[] { '\0' });
                    }
                }
            }
            catch { }
            des.Clear();

            return returnNull ? decrypt : (decrypt == null ? string.Empty : decrypt);
        }
        #endregion
    }
}
