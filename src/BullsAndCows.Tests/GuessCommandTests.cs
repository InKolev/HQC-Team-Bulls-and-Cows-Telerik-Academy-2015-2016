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
    public class GuessCommandTests
    {
        [TestMethod]
        public void GuessCommandShouldReturnCorrectBullsWhen3()
        {
            IDataState data = new Data();
            data.NumberToGuess = "1234";
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            GuessCommand guessCommand = new GuessCommand(data, notifier, "1235");
            guessCommand.Execute();
            Assert.AreEqual(3, data.Bulls);
        }

        [TestMethod]
        public void GuessCommandShouldReturnCorrectBullsWhenZero()
        {
            IDataState data = new Data();
            data.NumberToGuess = "1234";
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            GuessCommand guessCommand = new GuessCommand(data, notifier, "5678");
            guessCommand.Execute();
            Assert.AreEqual(0, data.Bulls);
        }

        [TestMethod]
        public void GuessCommandShouldReturnCorrectCowsWhen2()
        {
            IDataState data = new Data();
            data.NumberToGuess = "1234";
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            GuessCommand guessCommand = new GuessCommand(data, notifier, "2561");
            guessCommand.Execute();
            Assert.AreEqual(2, data.Cows);
        }

        [TestMethod]
        public void GuessCommandShouldReturnCorrectCowsWhenZero()
        {
            IDataState data = new Data();
            data.NumberToGuess = "1234";
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            GuessCommand guessCommand = new GuessCommand(data, notifier, "5678");
            guessCommand.Execute();
            Assert.AreEqual(0, data.Cows);
        }

        [TestMethod]
        public void GuessCommandShouldReturnCorrectBullsAndCowsWhen2And2()
        {
            IDataState data = new Data();
            data.NumberToGuess = "1234";
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            GuessCommand guessCommand = new GuessCommand(data, notifier, "4231");
            guessCommand.Execute();
            Assert.AreEqual(2, data.Cows);
            Assert.AreEqual(2, data.Bulls);
        }

        [TestMethod]
        public void GuessCommandShouldReturnCorrectBullsAndCowsWhen1And3()
        {
            IDataState data = new Data();
            data.NumberToGuess = "1234";
            INotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            GuessCommand guessCommand = new GuessCommand(data, notifier, "1342");
            guessCommand.Execute();
            Assert.AreEqual(3, data.Cows);
            Assert.AreEqual(1, data.Bulls);
        }
    }
}
