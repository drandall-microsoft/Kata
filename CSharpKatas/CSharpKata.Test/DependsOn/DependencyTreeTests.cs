using CSharpKatas.DependsOn;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

using static CSharpKatas.DependsOn.Dependency.Name;
using static CSharpKatas.DependsOn.Dependency.LoadingState;
using System.Linq;

namespace CSharpKata.Test.DependsOn
{
    [TestClass]
    public class DependencyTreeTests
    {
        private Dependency a;
        private Dependency b;
        private Dependency c;

        [TestInitialize]
        public void Setup()
        {
            DependencyLoader.ClearForTests();

            a = new Dependency(Zero, Update, Reset);
            b = new Dependency(One, Update, Reset, Zero);
            c = new Dependency(Two, Update, Reset, Zero, One);
        }

        [TestMethod]
        public void EmptyDependencyTree_IsInvalid()
        {
            Assert.ThrowsException<KeyNotFoundException>(() => new DependencyTree(Three));
        }

        [TestMethod]
        public void FreeDependency_ReturnsTheDependency()
        {
            var tree = new DependencyTree(Zero);
            var toLoad = tree.ReadyToLoad();

            Assert.AreEqual(1, toLoad.Count());
            Assert.AreEqual(a, toLoad.First());
        }

        [TestMethod]
        public void ReadyToLoad_OnlyReturnsDependenciesWhichAreReady()
        {
            var tree = new DependencyTree(Two);
            var toLoad = tree.ReadyToLoad();

            Assert.AreEqual(1, toLoad.Count());
            Assert.AreEqual(a, toLoad.First());
        }

        [TestMethod]
        public void ReadyToLoad_ChecksStatusOnEachCall()
        {
            var tree = new DependencyTree(Two);

            a.Load();
            a.Update();

            var toLoad = tree.ReadyToLoad();
            Assert.AreEqual(1, toLoad.Count());
            Assert.AreEqual(b, toLoad.First());

            b.Load();
            b.Update();

            toLoad = tree.ReadyToLoad();
            Assert.AreEqual(1, toLoad.Count());
            Assert.AreEqual(c, toLoad.First());
        }

        [TestMethod]
        public void ReadyToLoad_CanReturnMultipleEntries()
        {
            var d1 = new Dependency(Three, Update, Reset, Zero);
            var d2 = new Dependency(Four, Update, Reset, Zero);
            var d3 = new Dependency(Five, Update, Reset, Three, Four);

            var tree = new DependencyTree(Five);

            a.Load();
            a.Update();

            var toLoad = tree.ReadyToLoad();
            Assert.AreEqual(2, toLoad.Count()); //Three and Four
        }

        [TestMethod]
        public void DependencyTree_WithSimpleCyclicalDependency_Throws()
        {
            Dependency d1 = new Dependency(Three, Update, Reset, Four);
            Dependency d2 = new Dependency(Four, Update, Reset, Three);

            Assert.ThrowsException<Exception>(() => new DependencyTree(Three));
        }

        [TestMethod]
        public void DependencyTree_WithLongCyclicalDependency_Throws()
        {
            Dependency d1 = new Dependency(Three, Update, Reset, Four);
            Dependency d2 = new Dependency(Four, Update, Reset, Five);
            Dependency d3 = new Dependency(Five, Update, Reset, Three);

            Assert.ThrowsException<Exception>(() => new DependencyTree(Three));
        }

        [TestMethod]
        public void ListInOrder_ProducesDependenciesInListOrder()
        {
            var tree = new DependencyTree(Two);

            var asList = tree.ListInOrder().ToArray();
            Assert.AreEqual(3, asList.Length);
            Assert.AreEqual(Zero, asList[0].MyName);
            Assert.AreEqual(One, asList[1].MyName);
            Assert.AreEqual(Two, asList[2].MyName);
        }

        private Dependency.LoadingState Update()
        {
            return DoneLoading;
        }

        private Dependency.LoadingState Reset()
        {
            return DoneLoading;
        }
    }
}
