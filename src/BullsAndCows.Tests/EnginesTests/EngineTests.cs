﻿namespace BullsAndCows.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BullsAndCows.Core;

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

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void CheckIfEngineStartedAfterBeingInitializedDoesntThrowArgumentException()
        {
            var engine = new Engine();
            engine.Initialize();
            engine.Run();
        }
    }
}
