using CSharpKatas.DependsOn;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

using static CSharpKatas.DependsOn.Dependency.Known;

namespace CSharpKata.Test
{
    [TestClass]
    public class DependsOnTests
    {
        private Dependency noReset;
        private Dependency needsReset;

        private bool resetCalled;

        [TestInitialize]
        public void Setup()
        {
            noReset = new Dependency(Update, ResetNotNeeded);
            needsReset = new Dependency(Update, ResetNeeded);
        }

        [TestMethod]
        public void IsLoading_BeforeLoad_IsFalse()
        {
            Assert.IsFalse(noReset.IsLoading);
        }

        [TestMethod]
        public void IsLoading_AfterLoad_IsTrue()
        {
            noReset.Load();
            Assert.IsTrue(noReset.IsLoading);
        }

        [TestMethod]
        public void IsLoading_AfterLoadAndUpdate_IsFalse()
        {
            noReset.Load();
            noReset.Update();

            Assert.IsFalse(noReset.IsLoading);
        }

        [TestMethod]
        public void IsDone_BeforeLoad_IsFalse()
        {
            Assert.IsFalse(noReset.DoneLoading);
        }

        [TestMethod]
        public void IsDone_AfterLoad_IsFalse()
        {
            noReset.Load();
            Assert.IsFalse(noReset.DoneLoading);
        }

        [TestMethod]
        public void IsDone_AfterLoadAndUpdate_IsTrue()
        {
            noReset.Load();
            noReset.Update();

            Assert.IsTrue(noReset.DoneLoading);
        }

        [TestMethod]
        public void IsLoading_AfterLoadThenReset_IsFalse()
        {
            needsReset.Load();
            needsReset.Update();
            needsReset.Reset();

            Assert.IsFalse(needsReset.IsLoading);
        }

        [TestMethod]
        public void DoneLoading_AfterLoadThenReset_IsFalse()
        {
            needsReset.Load();
            needsReset.Update();
            needsReset.Reset();

            Assert.IsFalse(needsReset.DoneLoading);
        }

        [TestMethod]
        public void Reset_BeforeLoad_DoesNotInvokeResetMethod()
        {
            needsReset.Reset();

            Assert.IsFalse(resetCalled);
        }

        [TestMethod]
        public void Reset_BeforeDone_DoesNotInvokeResetMethod()
        {
            needsReset.Load();
            needsReset.Reset();

            Assert.IsFalse(resetCalled);
            Assert.IsFalse(needsReset.IsLoading);
        }

        [TestMethod]
        public void Reset_AfterDone_InvokesResetMethod()
        {
            needsReset.Load();
            needsReset.Update();
            needsReset.Reset();

            Assert.IsTrue(resetCalled);
        }

        private bool Update()
        {
            return true;
        }

        private bool ResetNeeded()
        {
            resetCalled = true;
            return true;
        }

        private bool ResetNotNeeded()
        {
            resetCalled = true;
            return false;
        }
    }
}
