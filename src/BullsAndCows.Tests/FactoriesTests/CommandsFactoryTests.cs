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
    public class CommandsFactoryTests
    {
        [TestMethod]
        public void GetCommandShouldCreateInitializeGameCommandWhenstringIsStart()
        {
            IDataState data = new Data();
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            var mockedScoreboard = new Mock<IScoreboard>();
            var commandsFactory = new CommandsFactory(data, notifier, numberGenerator, mockedScoreboard.Object);
            var result = (commandsFactory.GetCommand("start")).ToString();
            Assert.AreEqual(result, "BullsAndCows.Helpers.Commands.InitializeGameCommand");            
        }

        [TestMethod]
        public void GetCommandShouldCreateCheatCommandWhenstringIsHelp()
        {
            IDataState data = new Data();
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            var mockedScoreboard = new Mock<IScoreboard>();
            var commandsFactory = new CommandsFactory(data, notifier, numberGenerator, mockedScoreboard.Object);
            var result = (commandsFactory.GetCommand("help")).ToString();
            Assert.AreEqual(result, "BullsAndCows.Helpers.Commands.CheatCommand");
        }

        [TestMethod]
        public void GetCommandShouldCreateDisplayCommandsListCommandWhenstringIsCommands()
        {
            IDataState data = new Data();
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            var mockedScoreboard = new Mock<IScoreboard>();
            var commandsFactory = new CommandsFactory(data, notifier, numberGenerator, mockedScoreboard.Object);
            var result = (commandsFactory.GetCommand("commands")).ToString();
            Assert.AreEqual(result, "BullsAndCows.Helpers.Commands.DisplayCommandsListCommand");
        }

        [TestMethod]
        public void GetCommandShouldCreateDisplayScoreboardCommandWhenstringIsTop()
        {
            IDataState data = new Data();
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            var mockedScoreboard = new Mock<IScoreboard>();
            var commandsFactory = new CommandsFactory(data, notifier, numberGenerator, mockedScoreboard.Object);
            var result = (commandsFactory.GetCommand("top")).ToString();
            Assert.AreEqual(result, "BullsAndCows.Helpers.Commands.DisplayScoreboardCommand");
        }

        [TestMethod]
        public void GetCommandShouldCreateEmptyCommandWhenstringIsEmpty()
        {
            IDataState data = new Data();
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            var mockedScoreboard = new Mock<IScoreboard>();
            var commandsFactory = new CommandsFactory(data, notifier, numberGenerator, mockedScoreboard.Object);
            var result = (commandsFactory.GetCommand("empty")).ToString();
            Assert.AreEqual(result, "BullsAndCows.Helpers.Commands.EmptyCommand");
        }

        [TestMethod]
        public void GetCommandShouldCreateQuitGameCommandWhenstringIsQuit()
        {
            IDataState data = new Data();
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            var mockedScoreboard = new Mock<IScoreboard>();
            var commandsFactory = new CommandsFactory(data, notifier, numberGenerator, mockedScoreboard.Object);
            var result = (commandsFactory.GetCommand("quit")).ToString();
            Assert.AreEqual(result, "BullsAndCows.Helpers.Commands.QuitGameCommand");
        }

        [TestMethod]
        public void GetCommandShouldCreateExitGameCommandWhenstringIsExit()
        {
            IDataState data = new Data();
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            var mockedScoreboard = new Mock<IScoreboard>();
            var commandsFactory = new CommandsFactory(data, notifier, numberGenerator, mockedScoreboard.Object);
            var result = (commandsFactory.GetCommand("exit")).ToString();
            Assert.AreEqual(result, "BullsAndCows.Helpers.Commands.ExitGameCommand");
        }

        [TestMethod]
        public void GetCommandShouldCreateGuessCommandWhenstringIs1234()
        {
            IDataState data = new Data();
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            var mockedScoreboard = new Mock<IScoreboard>();
            var commandsFactory = new CommandsFactory(data, notifier, numberGenerator, mockedScoreboard.Object);
            var result = (commandsFactory.GetCommand("1234")).ToString();
            Assert.AreEqual(result, "BullsAndCows.Helpers.Commands.GuessCommand");
        }

        [TestMethod]
        public void GetCommandShouldCreateDisplayMessageCommandWhenstringIs123()
        {
            IDataState data = new Data();
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            var mockedScoreboard = new Mock<IScoreboard>();
            var commandsFactory = new CommandsFactory(data, notifier, numberGenerator, mockedScoreboard.Object);
            var result = (commandsFactory.GetCommand("123")).ToString();
            Assert.AreEqual(result, "BullsAndCows.Helpers.Commands.DisplayMessageCommand");
        }

        [TestMethod]
        public void GetCommandShouldCreateDisplayMessageCommandWhenstringIsGuessed()
        {
            IDataState data = new Data();
            data.NumberToGuess = "1234";
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            var mockedScoreboard = new Mock<IScoreboard>();
            var commandsFactory = new CommandsFactory(data, notifier, numberGenerator, mockedScoreboard.Object);
            var result = (commandsFactory.GetCommand("1234")).ToString();
            Assert.AreEqual(result, "BullsAndCows.Helpers.Commands.WinGameCommand");
        }
    }
}
