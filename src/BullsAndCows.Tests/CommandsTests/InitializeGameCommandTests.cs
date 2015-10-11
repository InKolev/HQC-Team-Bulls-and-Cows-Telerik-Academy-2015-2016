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

        [TestMethod]
        public void InitializeGameCommandShouldSetNumberToGuess()
        {
            var mockednumberGenerator = new Mock<INumberGenerator>();
            mockednumberGenerator.Setup(d => d.GenerateNumber(4)).Returns("1234");
            IDataState data = new Data();
            INotifier notifier = new ConsoleNotifier();
            InitializeGameCommand initializeCommand = new InitializeGameCommand(data, notifier, mockednumberGenerator.Object);
            initializeCommand.Execute();
            Assert.AreEqual("1234", data.NumberToGuess);
        }
    }
}
