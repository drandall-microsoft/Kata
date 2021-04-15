using CSharpKatas.RomanInteger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpKata.Test
{
    [TestClass]
    public class RomanIntegerTests
    {
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
    }
}
