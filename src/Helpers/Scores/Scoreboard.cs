namespace BullsAndCows.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    internal class Scoreboard : IScoreboard
    {
        private const byte TopPlayersDisplayCount = 10;

        public Scoreboard(IScoreNotifier notifier, IScoreSerializer serializer, IActionsReader actionsReader)
        {
            this.Notifier = notifier;
            this.Serializer = serializer;
            this.ActionsReader = actionsReader;
            this.Scores = this.Serializer.Load();
            this.Scores = this.Scores
                            .OrderBy(x => x.NumberOfGuesses)
                            .ThenBy(x => x.Time)
                            .ToList();
        }

        private IList<Score> Scores { get; set; }

        private IActionsReader ActionsReader { get; set; }
        private IScoreNotifier Notifier { get; set; }

        private IScoreSerializer Serializer { get; set; }

        public void AddToScoreboard(int guessAttempts, double playTime)
        {
            if (this.Scores.Count < TopPlayersDisplayCount || this.Scores[TopPlayersDisplayCount - 1].NumberOfGuesses > guessAttempts)
            {
                this.Notifier.Notify("Please enter your name for the scoreboard: ");

                string playerName = String.Empty;

                this.ActionsReader.Read(out playerName);

                Score playerScore = new Score(guessAttempts, playerName, playTime);
                                
                if (this.Scores.Count == TopPlayersDisplayCount)
                {
                    this.Scores[TopPlayersDisplayCount - 1] = playerScore;
                }
                else
                {
                    this.Scores.Add(playerScore);
                }

                this.Serializer.Save(this.Scores);
            }
        }

        public void DisplayTopScores()
        {
            if (this.Scores.Count > 0)
            {
                this.Notifier.DisplayScores(this.Scores);
            }
            else
            {
                this.Notifier.Notify("The scoreboard is empty.");
            }
        }
    }
}
