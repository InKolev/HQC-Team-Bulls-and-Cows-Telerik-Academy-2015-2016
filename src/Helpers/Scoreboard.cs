using BullsAndCows.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Helpers
{
    internal class Scoreboard : IScoreboard
    {
        private const byte TopPlayersDisplayCount = 10;

        public Scoreboard(IScoreNotifier notifier, IScoreSerializer serializer)
        {
            this.Notifier = notifier;
            this.Serializer = serializer;
            this.Scores = Serializer.Load();
        }

        private List<Score> Scores { get; set; }

        private IScoreNotifier Notifier { get; set; }

        private IScoreSerializer Serializer { get; set; }

        public void AddToScoreboard(int guessAttempts)
        {
            if (this.Scores.Count < TopPlayersDisplayCount || this.Scores[4].NumberOfGuesses > guessAttempts)
            {
                this.Notifier.Notify("Please enter your name for the scoreboard: ");

                string playerName = Console.ReadLine().Trim();
                Score playerScore = new Score(guessAttempts, playerName);

                this.Scores.Add(playerScore);
                this.Scores.Sort();

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
