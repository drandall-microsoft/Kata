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
        private NumberReverser reverser;

        [TestInitialize]
        public void Setup()
        {
            reverser = new NumberReverser();
        }

        [TestMethod]
        public void ReverseInteger_WithZero_ReturnZero()
        {
            Assert.AreEqual(0, reverser.Reverse(0));
        }

        [TestMethod]
        public void ReverseInteger_With123_Returns321()
        {
            Assert.AreEqual(321, reverser.Reverse(123));
        }

        [TestMethod]
        public void ReverseInteger_WithNegative123_ReturnsNegative321()
        {
            Assert.AreEqual(-321, reverser.Reverse(-123));
        }

        [TestMethod]
        public void ReverseInteger_With120_Returns21()
        {
            Assert.AreEqual(21, reverser.Reverse(120));
        }

        [TestMethod]
        public void ReverseInteger_With901000_Returns109()
        {
            Assert.AreEqual(109, reverser.Reverse(901000));
        }

        [TestMethod]
        public void ReverseInteger_WithIntMax_Returns0()
        {
            Assert.AreEqual(0, reverser.Reverse(int.MaxValue));
        }
    }
}
