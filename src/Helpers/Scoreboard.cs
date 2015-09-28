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

        public Scoreboard(INotifier notifier, IScoreSerializer serializer)
        {
            this.Notifier = notifier;
            this.Serializer = serializer;
            this.Scores = Serializer.Load();
        }

        private List<Score> Scores { get; set; }

        private INotifier Notifier { get; set; }

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
                int position = 1;
                int padLeftWidth = this.Scores.Max(x => x.PlayerName.Length);

                Console.WriteLine(new String('_', padLeftWidth + 17));
                Console.Write(new String('-', (padLeftWidth - 3) / 2) +"Player" + new String('-', (padLeftWidth - 3) / 2));
                Console.WriteLine(new String('-', 5) + "Attempts" + "-");
                Console.WriteLine();

                foreach (var score in this.Scores)
                {
                    this.Notifier.Notify(String.Format("{0}. {1} -- {2} guesses",
                        position++,
                        score.PlayerName.PadLeft(padLeftWidth),
                        score.NumberOfGuesses.ToString().PadRight(2)));
                }
                Console.WriteLine(new String('_', padLeftWidth + 17));
            }
            else
            {
                this.Notifier.Notify("The scoreboard is empty.");
            }
        }
    }
}
