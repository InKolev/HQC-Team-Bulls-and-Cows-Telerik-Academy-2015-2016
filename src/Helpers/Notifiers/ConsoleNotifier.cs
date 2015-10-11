// <copyright  file="ConsoleNotifier.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    /// <summary>
    /// Class for notifying the user
    /// </summary>
    internal class ConsoleNotifier : IScoreNotifier, INotifier
    {
        public ConsoleNotifier()
        {
            this.WindowWidth = Console.WindowWidth;
        }

        private int WindowWidth { get; set; }
        
        /// <summary>
        /// Displays the list with the scores
        /// </summary>
        /// <param name="scores"></param>
        public void DisplayScores(IList<Score> scores)
        {
            int padLeftWidth = scores.Max(x => x.PlayerName.Length);
            int scoreBoardWidth = padLeftWidth + 26;

            Console.WriteLine('┌' + new string('─', scoreBoardWidth) + '┐');
            Console.Write("├─" + new string('─', (int)Math.Ceiling((double)(padLeftWidth - 3) / 2)) + "Player" + new string('─', (padLeftWidth - 3) / 2));
            Console.WriteLine(new string('─', 4) + "Attempts" + new string('─', 5) + "Time" + "─┤");
            Console.WriteLine('│' + new string(' ', scoreBoardWidth) + '│');

            int position = 1;

            foreach (var score in scores)
            {
                Console.WriteLine(string.Format(
                                        "│{0}. {1} ── {2} guesses ── {3:00.00}│",
                                        position++,
                                        score.PlayerName.PadLeft(padLeftWidth),
                                        score.NumberOfGuesses.ToString().PadRight(2),
                                        score.Time));
            }

            Console.WriteLine('└' + new string('─', scoreBoardWidth) + '┘');
        }

        /// <summary>
        /// Notifies the user 
        /// </summary>
        /// <param name="message">Notification message</param>
        public void Notify(string message)
        {
            switch (message)
            {
                case "IntroductionCall":
                    {
                        this.DisplayIntroductionMessage();
                        break;
                    }

                case "CommandsCall":
                    {
                        this.DisplayCommandsList();
                        break;
                    }

                default:
                    {
                        Console.WriteLine(message);
                        break;
                    }
            }
        }

        /// <summary>
        /// Displays message in the beginning of the game
        /// </summary>
        private void DisplayIntroductionMessage()
        {
            string welcomeMessage = "   Welcome to “Bulls and Cows” game. Try to guess my secret 4-digit number. The digits inside the secret number cannot be repeated. Have fun!";

            Console.WriteLine(new string('*', this.WindowWidth - 1));
            Console.WriteLine(welcomeMessage);
            Console.WriteLine(new string('*', this.WindowWidth - 1));
        }

        /// <summary>
        /// Displays the available commands
        /// </summary>
        private void DisplayCommandsList()
        {
            Console.WriteLine("\"commands\" - to display the commands list.");
            Console.WriteLine("\"start\"    - to start a new game.");
            Console.WriteLine("\"quit\"     - to quit the current game.");
            Console.WriteLine("\"exit\"     - to exit the application.");
            Console.WriteLine("\"help\"     - to unveil a random secret digit (if you want to be a cheater).");
            Console.WriteLine("\"top\"      - to view the top scoreboard.");
        }
    }
}
