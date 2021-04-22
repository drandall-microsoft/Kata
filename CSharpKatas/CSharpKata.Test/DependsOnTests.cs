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
            bottomDependency = new Example();
            topDependency = new Example(bottomDependency);
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
            bottomDependency.Update();
            Assert.IsTrue(topDependency.CanLoad());
        }

        [TestMethod]
        public void CanLoad_AfterLoad_ReturnsFalse()
        {
            bottomDependency.Load();
            Assert.IsFalse(bottomDependency.CanLoad());
        }

        private class Example : Dependency
        {
            public Example(params Dependency[] dependencies) : base(dependencies)
            {
            }

            public override void Update()
            {
                FinishedLoading();
            }

            protected override void LoadImpl()
            {
            }
        }
    }
}
