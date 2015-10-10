using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows.Helpers;
using BullsAndCows.Helpers.Commands;
using BullsAndCows.Helpers.Misc;
using BullsAndCows.Interfaces;
using BullsAndCows.Core;
using Moq;

namespace BullsAndCows.Tests
{
    [TestClass]
    public class DisplayScoreboardCommandTests
    {
        [TestMethod]
        public void DisplayScoreboardCommandShouldCallScoreboard()
        {
            var mockedScoreboard = new Mock<IScoreboard>();
            ICommand displayScoreboard = new DisplayScoreboardCommand(mockedScoreboard.Object);
            displayScoreboard.Execute();
            mockedScoreboard.Verify(m => m.DisplayTopScores(), Times.Once);
        }
    }
}
