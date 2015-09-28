using BullsAndCows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Helpers
{
    internal class Scoreboard : IScoreboard
    {
        public Scoreboard(INotifier notifier)
        {
            this.Notifier = notifier;
        }

        private INotifier Notifier { get; set; }

        private SortedList<int, string> Scores { get; } = new SortedList<int, string>();

        private byte TopPlayersDisplayCount { get; } = 5;


        public void AddToScoreboard(int guessAttempts)
        {
            if (this.Scores.Count < this.TopPlayersDisplayCount || this.Scores.ElementAt(4).Key > guessAttempts)
            {
                this.Notifier.Notify("Please enter your name for the scoreboard: ");

                string playerName = Console.ReadLine().Trim();

                this.Scores.Add(guessAttempts, playerName);

                if (this.Scores.Count == 6)
                {
                    this.Scores.RemoveAt(5);
                }
            }
        }

        public void DisplayTopScores()
        {
            if (this.Scores.Count() > 0)
            {
                int position = 1;

                foreach (var score in this.Scores)
                {
                    this.Notifier.Notify(String.Format("{0}. {1} --> {2} guesses", position++, score.Value, score.Key));
                }
            }
            else
            {
                this.Notifier.Notify("The scoreboard is empty.");
            }
        }
    }
}
