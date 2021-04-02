using CSharpKatas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpKata.Test
{
    [TestClass]
    public class WorldGreeterTests
    {
        [TestMethod]
        public void WorldGreeterSaysHello()
        {
            var greeter = new WorldGreeter();

            Assert.IsFalse(string.IsNullOrEmpty(greeter.SayHello()));
        }
    }
}
