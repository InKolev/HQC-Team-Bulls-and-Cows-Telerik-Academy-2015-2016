﻿using System;
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
    public class QuitGameCommandTests
    {
        [TestMethod]
        public void DisplayCommandsListCommandShouldCallNotifier()
        {
            var mockedNotifier = new Mock<INotifier>();
            IDataState data = new Data();
            ICommand quitGameCommand = new QuitGameCommand(mockedNotifier.Object);
            quitGameCommand.Execute();
            mockedNotifier.Verify(m => m.Notify(It.IsAny<string>()), Times.Once);
        }
    }
}
