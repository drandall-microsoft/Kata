using CSharpKatas.DependsOn;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKata.Test
{
    [TestClass]
    public class DependsOnTests
    {
        private Dependency bottomDependency;
        private Dependency topDependency;

        [TestInitialize]
        public void Setup()
        {
            bottomDependency = new Dependency();
            topDependency = new Dependency(bottomDependency);
        }

        [TestMethod]
        public void CanLoad_DependencyWithNoDependencies_ReturnsTrue()
        {
            Assert.IsTrue(bottomDependency.CanLoad());
        }

        [TestMethod]
        public void CanLoad_DependencyWithNonLoadedDependency_ReturnsFalse()
        {
            Assert.IsFalse(topDependency.CanLoad());
        }

        [TestMethod]
        public void CanLoad_DependencyWithLoadedDependency_ReturnsTrue()
        {
            bottomDependency.Load();
            Assert.IsTrue(topDependency.CanLoad());
        }

        [TestMethod]
        public void CanLoad_AfterLoad_ReturnsFalse()
        {
            bottomDependency.Load();
            Assert.IsFalse(bottomDependency.CanLoad());
        }
    }
}
