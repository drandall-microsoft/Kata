using CSharpKatas.DependsOn;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static CSharpKatas.DependsOn.Dependency.Name;
using static CSharpKatas.DependsOn.Dependency.LoadingState;

namespace CSharpKata.Test.DependsOn
{
    [TestClass]
    public class DependencyTests
    {
        private Dependency noReset;
        private Dependency needsReset;

        private bool resetCalled;

        [TestInitialize]
        public void Setup()
        {
            noReset = new Dependency(Zero, Update, ResetNotNeeded);
            needsReset = new Dependency(One, Update, ResetNeeded);
        }

        [TestMethod]
        public void CurrentState_BeforeLoad_IsNotLoaded()
        {
            Assert.AreEqual(noReset.CurrentState, NotLoaded);
        }

        [TestMethod]
        public void CurrentState_AfterLoad_IsLoading()
        {
            noReset.Load();
            Assert.AreEqual(noReset.CurrentState, Loading);
        }

        [TestMethod]
        public void CurrentState_AfterLoadComplete_IsDoneLoading()
        {
            noReset.Load();
            noReset.Update();

            Assert.AreEqual(noReset.CurrentState, DoneLoading);
        }

        [TestMethod]
        public void CurrentState_AfterLoadThenReset_NeedsReset_IsNotLoaded()
        {
            needsReset.Load();
            needsReset.Update();
            needsReset.Reset();

            Assert.AreEqual(needsReset.CurrentState, NotLoaded);
        }

        [TestMethod]
        public void Reset_BeforeLoad_DoesNotInvokeResetMethod()
        {
            needsReset.Reset();

            Assert.IsFalse(resetCalled);
            Assert.AreEqual(needsReset.CurrentState, NotLoaded);
        }

        [TestMethod]
        public void Reset_BeforeDone_DoesNotInvokeResetMethod()
        {
            needsReset.Load();
            needsReset.Reset();

            Assert.IsFalse(resetCalled);
            Assert.AreEqual(needsReset.CurrentState, NotLoaded);
        }

        [TestMethod]
        public void Reset_AfterDone_InvokesResetMethod()
        {
            needsReset.Load();
            needsReset.Update();
            needsReset.Reset();

            Assert.IsTrue(resetCalled);
        }

        private Dependency.LoadingState Update()
        {
            return DoneLoading;
        }

        private Dependency.LoadingState ResetNeeded()
        {
            resetCalled = true;
            return NotLoaded;
        }

        private Dependency.LoadingState ResetNotNeeded()
        {
            resetCalled = true;
            return DoneLoading;
        }
    }
}
