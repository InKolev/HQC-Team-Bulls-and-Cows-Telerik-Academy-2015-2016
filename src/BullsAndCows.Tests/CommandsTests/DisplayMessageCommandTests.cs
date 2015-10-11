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
    public class DisplayMessageCommandTests
    {        
        [TestMethod]
        public void DisplayMessageCommandShouldCallNotifier()
        {
            var mockedNotifier = new Mock<INotifier>();
            IDataState data = new Data();
            ICommand displayMessage = new DisplayMessageCommand(mockedNotifier.Object, true, "");
            displayMessage.Execute();
            mockedNotifier.Verify(m => m.Notify(""), Times.Once);
        }
    }
}
