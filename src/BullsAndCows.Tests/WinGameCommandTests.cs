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
    public class WinGameCommandTests
    {
        [TestMethod]
        public void WinGameCommandShouldCallScoreboardIfNotHasCheated()
        {
            INotifier notifier = new ConsoleNotifier();
            var mockedScoreboard = new Mock<IScoreboard>();
            var data = new Data();
            data.HasCheated = false;
            data.PlayTime = 7;
            data.GuessAttempts = 3;
            ICommand winGameCommand = new WinGameCommand(notifier, mockedScoreboard.Object, data);
            winGameCommand.Execute();
            mockedScoreboard.Verify(m => m.AddToScoreboard(data.GuessAttempts, data.PlayTime), Times.Once);
        }

        [TestMethod]
        public void WinGameCommandShouldCallScoreboardIfHasCheated()
        {
            INotifier notifier = new ConsoleNotifier();
            var mockedScoreboard = new Mock<IScoreboard>();
            var data = new Data();
            data.HasCheated = true;
            data.PlayTime = 7;
            data.GuessAttempts = 3;
            ICommand winGameCommand = new WinGameCommand(notifier, mockedScoreboard.Object, data);
            winGameCommand.Execute();
            mockedScoreboard.Verify(m => m.AddToScoreboard(data.GuessAttempts, data.PlayTime), Times.Never);
        }

        [TestMethod]
        public void WinGameCommandShouldCallNotifier()
        {
            var mockedNotifier = new Mock<INotifier>();
            var mockedScoreboard = new Mock<IScoreboard>();
            IDataState data = new Data();
            ICommand winGameCommand = new WinGameCommand(mockedNotifier.Object, mockedScoreboard.Object, data);
            winGameCommand.Execute();
            mockedNotifier.Verify(m => m.Notify(It.IsAny<string>()), Times.Once);
        }
    }
}
