namespace BullsAndCows.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    internal class Scoreboard : IScoreboard
    {
        private const byte TopPlayersDisplayCount = 10;

        public Scoreboard(IScoreNotifier notifier, IScoreSerializer serializer)
        {
            this.Notifier = notifier;
            this.Serializer = serializer;
            this.Scores = this.Serializer.Load();
        }

        private IList<Score> Scores { get; set; }

        private IScoreNotifier Notifier { get; set; }

        private IScoreSerializer Serializer { get; set; }

        public void AddToScoreboard(int guessAttempts)
        {
            if (this.Scores.Count < TopPlayersDisplayCount || this.Scores[TopPlayersDisplayCount - 1].NumberOfGuesses > guessAttempts)
            {
                this.Notifier.Notify("Please enter your name for the scoreboard: ");

                string playerName = Console.ReadLine().Trim();
                Score playerScore = new Score(guessAttempts, playerName);

                this.Scores.Add(playerScore);
                this.Scores.OrderBy(x => x.NumberOfGuesses);

                if (this.Scores.Count > TopPlayersDisplayCount)
                {
                    this.Scores.RemoveAt(TopPlayersDisplayCount);
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
