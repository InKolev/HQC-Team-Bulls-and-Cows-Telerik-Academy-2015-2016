using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows.Interfaces;
using Moq;
using BullsAndCows.Helpers;
using System.Collections;

namespace BullsAndCows.Tests
{
    [TestClass]
    public class ScoreboardTests
    {
        private IScoreNotifier notifier;
        private IScoreSerializer serializer;
        private IActionsReader actionsReader;
        private IList<Score> scores;

        public ScoreboardTests()
        {
            var mockNotifier = new Mock<IScoreNotifier>();
            mockNotifier.Setup(n => n.Notify(It.IsAny<string>())).Verifiable();
            this.notifier = mockNotifier.Object;

            var mockReader = new Mock<IActionsReader>();
            mockReader.Setup(r => r.Read()).Returns("Score4");
            this.actionsReader = mockReader.Object;
        }

        [TestInitialize]
        public void CreteScoresList()
        {
            this.scores = new List<Score>();
            this.scores.Add(new Score(1, "Score1", 5));
            this.scores.Add(new Score(2, "Score2", 6));
            this.scores.Add(new Score(3, "Score3", 7));
        }

        [TestMethod]
        public void ScoreboardShouldAddNewScoresWhenBoardIsNotFull()
        {
            var mockSerializer = new Mock<IScoreSerializer>();
            mockSerializer.Setup(s => s.Load()).Returns(this.scores);
            mockSerializer.Setup(s => s.Save(It.Is<IList<Score>>(l => l.Count == 4))).Verifiable();
            serializer = mockSerializer.Object;

            var scoreBoard = new Scoreboard(notifier, serializer, actionsReader);
            scoreBoard.AddToScoreboard(4, 5);

            mockSerializer.Verify();
        }

        [TestMethod]
        public void ScoreboardShouldNotAddIfScoreIsLowAndBoardIsFull()
        {
            this.scores.Add(new Score(1, "Score1", 5));
            this.scores.Add(new Score(2, "Score2", 6));
            this.scores.Add(new Score(3, "Score3", 7));
            this.scores.Add(new Score(1, "Score1", 5));
            this.scores.Add(new Score(2, "Score2", 6));
            this.scores.Add(new Score(3, "Score3", 7));
            this.scores.Add(new Score(3, "Score3", 7));

            var mockSerializer = new Mock<IScoreSerializer>();
            mockSerializer.Setup(s => s.Load()).Returns(this.scores);
            mockSerializer.Setup(s => s.Save(It.IsAny<IList<Score>>()));
            serializer = mockSerializer.Object;

            var scoreBoard = new Scoreboard(notifier, serializer, actionsReader);
            scoreBoard.AddToScoreboard(4, 5);

            mockSerializer.Verify(s => s.Save(It.IsAny<IList<Score>>()), Times.Never);
        }

        [TestMethod]
        public void ScoreboardShouldAddIfScoreIsHighAndBoardIsFull()
        {
            this.scores.Add(new Score(1, "Score1", 5));
            this.scores.Add(new Score(2, "Score2", 6));
            this.scores.Add(new Score(3, "Score3", 7));
            this.scores.Add(new Score(1, "Score1", 5));
            this.scores.Add(new Score(2, "Score2", 6));
            this.scores.Add(new Score(3, "Score3", 7));
            this.scores.Add(new Score(3, "Score3", 7));

            var mockSerializer = new Mock<IScoreSerializer>();
            mockSerializer.Setup(s => s.Load()).Returns(this.scores);
            mockSerializer.Setup(s => s.Save(It.IsAny<IList<Score>>()));
            serializer = mockSerializer.Object;

            var scoreBoard = new Scoreboard(notifier, serializer, actionsReader);
            scoreBoard.AddToScoreboard(2, 5);

            mockSerializer.Verify(s => s.Save(It.IsAny<IList<Score>>()), Times.Once);
        }
    }
}
