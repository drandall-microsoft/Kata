using CSharpKatas.RomanInteger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharpKata.Test
{
    [TestClass]
    public class RomanIntegerTests
    {
        [TestMethod]
        public void GivenZero_ToRoman_ThrowsException()
        {
            Assert.ThrowsException<Exception>(() => 0.ToRoman());
        }

        [TestMethod]
        public void GivenOne_ToRoman_ReturnsI()
        {
            Assert.AreEqual("I", 1.ToRoman());
        }

        [TestMethod]
        public void GivenFive_ToRoman_ReturnsV()
        {
            Assert.AreEqual("V", 5.ToRoman());
        }

        [TestMethod]
        public void GivenTen_ToRoman_ReturnsX()
        {
            Assert.AreEqual("X", 10.ToRoman());
        }

        [TestMethod]
        public void GivenFifty_ToRoman_ReturnsL()
        {
            Assert.AreEqual("L", 50.ToRoman());
        }

        [TestMethod]
        public void GivenHundred_ToRoman_ReturnsC()
        {
            Assert.AreEqual("C", 100.ToRoman());
        }

        [TestMethod]
        public void GivenFiveHundered_ToRoman_ReturnsD()
        {
            Assert.AreEqual("D", 500.ToRoman());
        }

        [TestMethod]
        public void GivenOneThousand_ToRoman_ReturnsM()
        {
            Assert.AreEqual("M", 1000.ToRoman());
        }

        [TestMethod]
        public void GivenTwo_ToRoman_ReturnsII()
        {
            Assert.AreEqual("II", 2.ToRoman());
        }

        [TestMethod]
        public void GivenSix_ToRoman_ReturnsVI()
        {
            Assert.AreEqual("VI", 6.ToRoman());
        }

        [TestMethod]
        public void GivenFour_ToRoman_ReturnsIV()
        {
            Assert.AreEqual("IV", 4.ToRoman());
        }

        [TestMethod]
        public void GivenNine_ToRoman_ReturnsIX()
        {
            Assert.AreEqual("IX", 9.ToRoman());
        }

        [TestMethod]
        public void GivenTwentyNine_ToRoman_ReturnsXXIX()
        {
            Assert.AreEqual("XXIX", 29.ToRoman());
        }

    }
}
