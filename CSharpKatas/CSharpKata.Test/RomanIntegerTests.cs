using CSharpKatas.RomanInteger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharpKata.Test
{
    [TestClass]
    public class RomanIntegerTests
    {
        [TestMethod]
        public void Zero_ToRoman_ThrowsException()
        {
            Assert.ThrowsException<Exception>(() => 0.ToRoman());
        }

        [TestMethod]
        public void One_ToRoman_ReturnsI()
        {
            Assert.AreEqual("I", 1.ToRoman());
        }

        [TestMethod]
        public void Five_ToRoman_ReturnsV()
        {
            Assert.AreEqual("V", 5.ToRoman());
        }

        [TestMethod]
        public void Ten_ToRoman_ReturnsX()
        {
            Assert.AreEqual("X", 10.ToRoman());
        }

        [TestMethod]
        public void Fifty_ToRoman_ReturnsL()
        {
            Assert.AreEqual("L", 50.ToRoman());
        }

        [TestMethod]
        public void Hundred_ToRoman_ReturnsC()
        {
            Assert.AreEqual("C", 100.ToRoman());
        }

        [TestMethod]
        public void FiveHundered_ToRoman_ReturnsD()
        {
            Assert.AreEqual("D", 500.ToRoman());
        }

        [TestMethod]
        public void OneThousand_ToRoman_ReturnsM()
        {
            Assert.AreEqual("M", 1000.ToRoman());
        }

        [TestMethod]
        public void Two_ToRoman_ReturnsII()
        {
            Assert.AreEqual("II", 2.ToRoman());
        }

        [TestMethod]
        public void Six_ToRoman_ReturnsVI()
        {
            Assert.AreEqual("VI", 6.ToRoman());
        }

        [TestMethod]
        public void Four_ToRoman_ReturnsIV()
        {
            Assert.AreEqual("IV", 4.ToRoman());
        }

        [TestMethod]
        public void Nine_ToRoman_ReturnsIX()
        {
            Assert.AreEqual("IX", 9.ToRoman());
        }

        [TestMethod]
        public void TwentyNine_ToRoman_ReturnsXXIX()
        {
            Assert.AreEqual("XXIX", 29.ToRoman());
        }

        [TestMethod]
        public void Forty_ToRoman_ReturnsXL()
        {
            Assert.AreEqual("XL", 40.ToRoman());
        }

        [TestMethod]
        public void Ninety_ToRoman_ReturnXC()
        {
            Assert.AreEqual("XC", 90.ToRoman());
        }

        [TestMethod]
        public void NinetyOne_ToRoman_ReturnsXCI()
        {
            Assert.AreEqual("XCI", 91.ToRoman());
        }

        [TestMethod]
        public void ToRoman_FromRoman_ReturnsOriginal()
        {
            for (int i = 1; i < 3000; i++)
            {
                Assert.AreEqual(i, (i.ToRoman()).FromRoman());
            }
        }
    }
}
