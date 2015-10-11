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
    public class CommandsFactoryTests
    {
        [TestMethod]
        public void GetCommandShouldCreateInitializeGameCommandWhenStringIsStart()
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
        public void GetCommandShouldCreateCheatCommandWhenStringIsHelp()
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
        public void GetCommandShouldCreateDisplayCommandsListCommandWhenStringIsCommands()
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
        public void GetCommandShouldCreateDisplayScoreboardCommandWhenStringIsTop()
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
        public void GetCommandShouldCreateEmptyCommandWhenStringIsEmpty()
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
        public void GetCommandShouldCreateQuitGameCommandWhenStringIsQuit()
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
        public void GetCommandShouldCreateExitGameCommandWhenStringIsExit()
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
        public void GetCommandShouldCreateGuessCommandWhenStringIs1234()
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
        public void GetCommandShouldCreateDisplayMessageCommandWhenStringIs123()
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
        public void GetCommandShouldCreateDisplayMessageCommandWhenStringIsGuessed()
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
