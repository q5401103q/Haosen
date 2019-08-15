using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Haosen.Common.Security
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2019/8/15 14:42:04
    /// 描述：MD5工具类
    /// </summary>
    public class MD5Helper
    {
        private static string Compute32BitMD5(string val)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] source = Encoding.GetEncoding("utf-8").GetBytes(val);
            byte[] result = provider.ComputeHash(source);
            StringBuilder sb = new StringBuilder();
            foreach (byte resultByte in result)
            {
                sb.Append(resultByte.ToString("x2"));
            }
            return sb.ToString();
        }

        private static string Compute16BitMD5(string val)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] source = Encoding.GetEncoding("utf-8").GetBytes(val);
            byte[] result = provider.ComputeHash(source);
            string hash = BitConverter.ToString(result, 4, 8).Replace("-", ""); ;
            return hash;
        }

        /// <summary>
        /// 计算MD5值
        /// </summary>
        /// <param name="val">被计算的字符串</param>
        /// <param name="isUpper">结果是否大写，true大写；false小写；默认是小写</param>
        /// <param name="is16Bit">结果是否为16位长度，true16位；false32位；默认是32位</param>
        /// <returns>md5</returns>
        public static string ComputeMD5(string val, bool isUpper = false, bool is16Bit = false)
        {
            string result = string.Empty;
            if (is16Bit)
            {
                result = Compute16BitMD5(val);
            }
            else
            {
                result = Compute32BitMD5(val);
            }
            return isUpper ? result.ToUpper() : result.ToLower();
        }
    }
}
