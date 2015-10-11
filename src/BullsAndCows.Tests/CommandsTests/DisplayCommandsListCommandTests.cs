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
    public class DisplayCommandsListCommandTests
    {
        [TestMethod]
        public void DisplayCommandsListCommandShouldCallNotifier()
        {
            var mockedNotifier = new Mock<INotifier>();
            IDataState data = new Data();
            ICommand displayCommandsList = new DisplayCommandsListCommand(mockedNotifier.Object);
            displayCommandsList.Execute();
            mockedNotifier.Verify(m => m.Notify(It.IsAny<string>()), Times.Once);
        }
    }
}
