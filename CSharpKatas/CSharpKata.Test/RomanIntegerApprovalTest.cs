using ApprovalTests;
using ApprovalTests.Reporters;
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
        public void TestList()
        {
            var names = new[] { "Llewellyn", "James", "Dan", "Jason", "Katrina" };
            Array.Sort(names);
            Approvals.VerifyAll(names, label: "");
        }

    }
}
