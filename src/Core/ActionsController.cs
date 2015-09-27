using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BullsAndCows.Helpers;
using System.Text.RegularExpressions;
using BullsAndCows.Interfaces;

namespace BullsAndCows.Core
{
    internal class ActionsController
    {
        // Constructors
        public ActionsController(INotifier notifier, IScoreboard scoreboard)
        {
            this.Notifier = notifier;
            this.Scoreboard = scoreboard;
        }

        // Properties
        private Random RandomGenerator { get; set; } = new Random();

        private Regex FourDigitNumberPattern { get; set; } = new Regex("[1-9][0-9][0-9][0-9]");

        private INotifier Notifier { get; set; }

        private IScoreboard Scoreboard { get; set; }

        private string CheatHelper { get; set; }

        private string NumberToGuess { get; set; }

        private bool HasCheated { get; set; }

        private int GuessAttempts { get; set; }

        // Methods
        private string GenerateNumber(int digits)
        {
            var generatedNumber = new StringBuilder();

            while (generatedNumber.Length < digits)
            {
                var digit = this.RandomGenerator.Next(0, 10).ToString();

                if (!(generatedNumber.ToString().Contains(digit)))
                {
                    generatedNumber.Append(digit);
                }
            }

            return generatedNumber.ToString();
        }

        public bool ReadAction(Scoreboard scoreboard)
        {
            this.Notifier.Notify("Guess");

            string input = Console.ReadLine().Trim();

            switch (input)
            {
                case "TOP":
                    {
                        this.Scoreboard.DisplayTopScores();
                        break;
                    }
                case "START":
                    {
                        StartNewGame();
                        break;
                    }
                case "HELP":
                    {
                        HelpTheCheater();
                        break;
                    }
                case "EXIT":
                    {
                        return false;
                    }
                default:
                    if (this.FourDigitNumberPattern.IsMatch(input))
                    {
                        ProcessGuess(input, scoreboard);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a 4-digit number or");
                        Console.WriteLine("one of the commands: 'top', 'restart', 'help' or 'exit'.");
                    }

                    break;
            }

            return true;
        }

        public void ProcessWin(Scoreboard scoreboard)
        {
            Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts.", this.GuessAttempts);

            if (!this.HasCheated)
            {
                scoreboard.AddToScoreboard(this.GuessAttempts);
            }
        }

        public void ProcessGuess(string guess, Scoreboard scoreboard)
        {
            if (guess.Equals(this.NumberToGuess))
            {
                ProcessWin(scoreboard);
            }
            else
            {
                int bulls = 0, cows = 0;

                for (int i = 0; i < this.NumberToGuess.Length; i++)
                {
                    if (this.NumberToGuess[i].Equals(guess[i]))
                    {
                        bulls++;
                    }
                    else if (this.NumberToGuess.Contains(guess[i]))
                    {
                        cows++;
                    }
                }

                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
                this.GuessAttempts++;
            }
        }

        public void StartNewGame()
        {
            this.Notifier.Notify("Introduction");
            this.Notifier.Notify("Commands");

            this.NumberToGuess = GenerateNumber(4);
            this.GuessAttempts = 1;
            this.CheatHelper = "XXXX";
            this.HasCheated = false;
        }

        public void HelpTheCheater()
        {
            this.HasCheated = true;

            if (this.CheatHelper.Contains('X'))
            {
                int i;

                do
                {
                    i = this.RandomGenerator.Next(0, 4);
                }
                while (this.CheatHelper[i] != 'X');

                char[] cheatHelperChars = this.CheatHelper.ToCharArray();
                cheatHelperChars[i] = this.NumberToGuess.ToString()[i];
                this.CheatHelper = new string(cheatHelperChars);
            }

            Console.WriteLine("The number looks like {0}.", this.CheatHelper);
        }
    }
}
