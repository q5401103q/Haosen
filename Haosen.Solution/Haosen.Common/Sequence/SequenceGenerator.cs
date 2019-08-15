using System;
using System.Collections.Generic;
using System.Text;

namespace Haosen.Common.Sequence
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2019/8/15 14:11:20
    /// 描述：序列生成器
    /// </summary>
    public class SequenceGenerator
    {
        /// <summary>
        /// 互斥锁
        /// </summary>
        private static object locker = new object();
        /// <summary>
        /// 开始序号
        /// </summary>
        private static int Index = 0;
        /// <summary>
        /// 前缀
        /// </summary>
        private static readonly string DefaultPrefix = "SEQ";
        /// <summary>
        /// 后缀
        /// </summary>
        private static readonly string DefaultSuffix = "";
        
        /// <summary>
        /// 使用默认的前缀和后缀生成序列
        /// </summary>
        /// <returns>序列</returns>
        public static string Next()
        {
            return Next(DefaultPrefix, DefaultSuffix);
        }

        /// <summary>
        /// 使用给定的前缀和默认后缀生成序列
        /// </summary>
        /// <param name="Prefix">给定的前缀</param>
        /// <returns>序列</returns>
        public static string Next(string Prefix)
        {
            return Next(Prefix, DefaultSuffix);
        }

        /// <summary>
        /// 使用给定的前缀和后缀生成序列
        /// </summary>
        /// <param name="Prefix">给定的前缀</param>
        /// <param name="Suffix">给定的后缀</param>
        /// <returns>序列</returns>
        public static string Next(string Prefix, string Suffix)
        {
            lock (locker)
            {
                if (Index == int.MaxValue - 1)
                {
                    Index = 0;
                }
                else
                {
                    Index++;
                }

                //如果没有后缀，不需要将后缀拼入结果
                if (string.IsNullOrEmpty(Suffix))
                {
                    return $"{Prefix}-{DateTime.Now.ToString("yyyyMMddHHmmss")}-{Index.ToString().PadLeft(6, '0')}";
                }

                return $"{Prefix}-{DateTime.Now.ToString("yyyyMMddHHmmss")}-{Index.ToString().PadLeft(6, '0')}-{Suffix}";
            }
        }


        /// <summary>
        /// 防止创建类的实例
        /// </summary>
        private SequenceGenerator()
        {

        }
    }
}
