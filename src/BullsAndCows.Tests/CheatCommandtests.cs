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
    public class CheatCommandTests
    {
        [TestMethod]
        public void CheatCommandExecuteShouldUpdateHasCheated()
        {
            IDataState data = new Data();
            data.NumberToGuess = "1234";
            data.CheatHelper = "XXXX";
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            CheatCommand cheatCommand = new CheatCommand(data, notifier, numberGenerator);
            cheatCommand.Execute();
            Assert.AreEqual(true, data.HasCheated);
        }

        [TestMethod]
        public void CheatCommandShouldUpdateCheatHelper()
        {
            var mockednumberGenerator = new Mock<INumberGenerator>();
            mockednumberGenerator.Setup(d => d.Next(0, 4)).Returns(1);
            IDataState data = new Data();
            data.NumberToGuess = "1234";
            data.CheatHelper = "XXXX";
            INotifier notifier = new ConsoleNotifier();
            CheatCommand cheatCommand = new CheatCommand(data, notifier, mockednumberGenerator.Object);
            cheatCommand.Execute();
            Assert.AreEqual("X2XX", data.CheatHelper);
        }
    }
}
