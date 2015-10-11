using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCows.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BullsAndCows.Helpers;
    using BullsAndCows.Helpers.Commands;
    using BullsAndCows.Helpers.Misc;
    using BullsAndCows.Interfaces;
    using BullsAndCows.Core;
    using Moq;


    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckIfEngineStartedWithoutBeingInitializedThrowsArgumentException()
        {
            var engine = new Engine();
            engine.Run();
        }

        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        [TestMethod]
        public void CheckIfEngineStartedAfterBeingInitializedDoesntThrowArgumentException()
        {
            var engine = new Engine();
            engine.Initialize();
            engine.Run();
        }
    }
}
