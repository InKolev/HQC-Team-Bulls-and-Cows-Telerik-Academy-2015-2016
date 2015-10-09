namespace BullsAndCows.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    internal class ConsoleNotifier : IScoreNotifier, INotifier
    {
        public ConsoleNotifier()
        {
            this.WindowWidth = Console.WindowWidth;
        }

        private int WindowWidth { get; set; }
        
        public void DisplayScores(IList<Score> scores)
        {
            int padLeftWidth = scores.Max(x => x.PlayerName.Length);
            int scoreBoardWidth = padLeftWidth + 26;

            Console.WriteLine('┌' + new String('─', scoreBoardWidth) + '┐');
            Console.Write("├─" + new String('─', (int)Math.Ceiling((double)(padLeftWidth - 3) / 2)) + "Player" + new String('─', (padLeftWidth - 3) / 2));
            Console.WriteLine(new String('─', 4) + "Attempts" + new String('─', 5) + "Time" + "─┤");
            Console.WriteLine('│' + new String(' ', scoreBoardWidth) + '│');

            int position = 1;

            foreach (var score in scores)
            {
                Console.WriteLine(String.Format(
                                        "│{0}. {1} ── {2} guesses ── {3:00.00}│",
                                        position++,
                                        score.PlayerName.PadLeft(padLeftWidth),
                                        score.NumberOfGuesses.ToString().PadRight(2),
                                        score.Time));
            }

            Console.WriteLine('└' + new String('─', scoreBoardWidth) + '┘');
        }

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

        private void DisplayIntroductionMessage()
        {
            string welcomeMessage = "   Welcome to “Bulls and Cows” game. Try to guess my secret 4-digit number. The digits inside the secret number cannot be repeated. Have fun!";

            Console.WriteLine(new String('*', this.WindowWidth - 1));
            Console.WriteLine(welcomeMessage);
            Console.WriteLine(new String('*', this.WindowWidth - 1));
        }

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
