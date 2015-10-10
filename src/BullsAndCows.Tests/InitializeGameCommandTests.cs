using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows.Helpers;
using BullsAndCows.Helpers.Commands;
using BullsAndCows.Helpers.Misc;
using BullsAndCows.Interfaces;
using BullsAndCows.Core;

namespace BullsAndCows.Tests
{
    [TestClass]
    public class InitializeGameCommandTests
    {
        [TestMethod]
        public void InitializeGameCommandShouldSetGuessAttemptsMaxValue()
        {
            IDataState data = new Data();
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            InitializeGameCommand initializeCommand = new InitializeGameCommand(data, notifier, numberGenerator);
            initializeCommand.Execute();
            Assert.AreEqual(25, data.GuessAttemptsMaxValue);
        }
    }
}
