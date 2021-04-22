using CSharpKata.NumberReverse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKata.Test
{
    [TestClass]
    public class NumberReverseTests
    {
        [TestMethod]
        public void ReverseInteger_WithZero_ReturnZero()
        {
            var reverser = new NumberReverser();
            Assert.AreEqual(0, reverser.Reverse(0));
        }
    }
}
