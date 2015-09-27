using BullsAndCows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Helpers
{
    internal class Scoreboard : IScoreboard
    {
        private SortedList<int, string> Scores { get; set; } = new SortedList<int, string>();

        private byte TopPlayersDisplayCount { get; set; } = 5;

        public void AddToScoreboard(int guessAttempts)
        {
            if (this.Scores.Count < this.TopPlayersDisplayCount || this.Scores.ElementAt(4).Key > guessAttempts)
            {
                Console.WriteLine("Please enter your name for the top scoreboard: ");

                string playerName = Console.ReadLine().Trim();

                this.Scores.Add(guessAttempts, playerName);

                if (this.Scores.Count == 6)
                {
                    this.Scores.RemoveAt(5);
                }

                DisplayTopScores();
            }
        }

        public void DisplayTopScores()
        {
            if (this.Scores.Count() > 0)
            {
                int position = 1;

                foreach (var score in this.Scores)
                {
                    Console.WriteLine("{0}. {1} --> {2} guesses", position++, score.Value, score.Key);
                }
            }
            else
            {
                Console.WriteLine("The Scoreboard is empty.");
            }
        }
    }
}
