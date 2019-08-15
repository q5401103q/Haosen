using Haosen.Common.sequence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Haosen.Api.Test
{
    [TestClass]
    class TestSequence
    {
        [TestMethod]
        public void TestSeq()
        {
            var str1 = SequenceGenerator.Next();
            var str2 = SequenceGenerator.Next("LIUZL");
            var str3 = SequenceGenerator.Next("LIUZL", "RELEASE");

            Debug.WriteLine(str1);
            Debug.WriteLine(str2);
            Debug.WriteLine(str3);

            Assert.IsTrue(str1.Length > 0);
        }
    }
}
