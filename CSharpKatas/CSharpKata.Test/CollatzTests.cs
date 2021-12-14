using CSharpKatas.Collatz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharpKata.Test
{
    [TestClass]
    public class CollatzTests
    {
        private CollatzPrinter printer;
        private Stream stream;

        [TestInitialize]
        public void Setup()
        {
            stream = new MemoryStream();
            printer = new CollatzPrinter(stream);
        }

        [TestCleanup]
        public void TearDown()
        {
            stream.Dispose();
        }

        [TestMethod]
        public void PrintCollatz_WithOne_PrintsOne()
        {
            Assert.AreEqual("1", Run(1));
        }

        [TestMethod]
        public void PrintCollatz_WithFive_PrintsSeries()
        {
            Assert.AreEqual("5, 16, 8, 4, 2, 1", Run(5));
        }

        private string Run(uint input)
        {
            printer.PrintCollatz(input);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
