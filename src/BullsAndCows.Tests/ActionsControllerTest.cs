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
    public class ActionsControllerTest
    {
        [TestMethod]
        public void CheckIfActionsControllerReadActionMethodReturnsTrueWhenDisplayCommandsCommandIsCalled()
        {
            var data = new Data();

            var mockednumberGenerator = new Mock<INumberGenerator>();

            var mockedScoreboard = new Mock<IScoreboard>();

            var mockedActionsReader = new Mock<IActionsReader>();
            mockedActionsReader.Setup(x => x.Read())
                .Returns("exit");

            var mockedNotifier = new Mock<INotifier>();
            mockedNotifier.Setup(x => x.Notify(
                It.IsAny<string>()));

            var mockedCommandsFactory = new Mock<ICommandsFactory>();
            mockedCommandsFactory.Setup(x => x.GetCommand(
                It.IsAny<string>()))
                .Returns(new EmptyCommand());

            var controller = new ActionsController(data, mockedNotifier.Object, mockednumberGenerator.Object, mockedScoreboard.Object, mockedCommandsFactory.Object, mockedActionsReader.Object);
            controller.Run();

            Assert.AreEqual(true, controller.IsRunning);
        }
    }
}
