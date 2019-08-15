using Haosen.Common.Security;
using Haosen.Common.Sequence;
using System;

namespace Haosen.Api.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "123456789012345678901234";
            var plain = "这个玩意是一个普通的字符串，用于测试加密和解密的过程";

            var str1 = DESHelper.EncryptByCBC(plain, key);
            var tmp1 = DESHelper.DecryptByCBC(str1, key);

            var str2 = DESHelper.EncryptByEBC(plain, key);
            var tmp2 = DESHelper.DecryptByEBC(str2, key);

            Console.WriteLine(str1);
            Console.WriteLine(tmp1);
            Console.WriteLine();
            Console.WriteLine(str2);
            Console.WriteLine(tmp2);

            Console.WriteLine("=============================================");

            var str3 = AESHelper.EncryptByCBC(plain, key);
            var tmp3 = AESHelper.DecryptByCBC(str3, key);

            var str4 = AESHelper.EncryptByEBC(plain, key);
            var tmp4 = AESHelper.DecryptByEBC(str4, key);

            Console.WriteLine(str3);
            Console.WriteLine(tmp3);
            Console.WriteLine();
            Console.WriteLine(str4);
            Console.WriteLine(tmp4);

            Console.WriteLine("=============================================");
            Console.WriteLine(MD5Helper.ComputeMD5(plain));
            Console.WriteLine(MD5Helper.ComputeMD5(plain, true));
            Console.WriteLine(MD5Helper.ComputeMD5(plain, true, true));
            Console.WriteLine(MD5Helper.ComputeMD5(plain, false, true));

            Console.Read();
        }
    }
}
