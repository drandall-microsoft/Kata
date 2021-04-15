using ApprovalTests;
using ApprovalTests.Reporters;
using CSharpKatas.RomanInteger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKata.Test
{
    [UseReporter(typeof(VisualStudioReporter))]
    [TestClass]
    public class RomanIntegerApprovalTest
    {
        [TestMethod]
        public void AllRomanNumerals()
        {
            var result = new Dictionary<int, string>();
            for (int i = 1; i <= 3000; i++)
            {
                result[i] = i.ToRoman();
            }

            Approvals.VerifyAll(result);
        }
    }
}
