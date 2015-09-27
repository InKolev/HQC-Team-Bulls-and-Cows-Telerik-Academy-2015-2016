using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BullsAndCows.Helpers;
using System.Text.RegularExpressions;
using BullsAndCows.Interfaces;

namespace BullsAndCows.Core
{
    internal class ActionsController : IController
    {
        public ActionsController(INotifier notifier, IScoreboard scoreboard)
        {
            this.Notifier = notifier;
            this.Scoreboard = scoreboard;
        }


        private Random RandomGenerator { get; set; } = new Random();

        private Regex FourDigitNumberPattern { get; set; } = new Regex("[1-9][0-9][0-9][0-9]");

        private INotifier Notifier { get; set; }

        private IScoreboard Scoreboard { get; set; }

        private string CheatHelper { get; set; }

        private string NumberToGuess { get; set; }

        private bool HasCheated { get; set; }

        private int GuessAttempts { get; set; }


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

        private bool ReadAction()
        {
            this.Notifier.Notify("Guess");

            string input = Console.ReadLine().Trim();

            switch (input)
            {

                case "START":
                    {
                        Initialize();
                        break;
                    }
                case "HELP":
                    {
                        ProcessCheat();
                        break;
                    }
                case "TOP":
                    {
                        this.Scoreboard.DisplayTopScores();
                        break;
                    }
                case "EXIT":
                    {
                        this.Notifier.Notify("Exit");
                        return false;
                    }
                case "COMMANDS":
                    {
                        this.Notifier.Notify("Commands");
                        break;
                    }
                default:
                    if (this.FourDigitNumberPattern.IsMatch(input))
                    {
                        ProcessGuess(input);
                    }
                    else
                    {
                        // TODO: Extract to notifier.
                        Console.WriteLine("Please enter a 4-digit number or");
                        Console.WriteLine("one of the commands: 'top', 'restart', 'help' or 'exit'.");
                    }

                    break;
            }

            return true;
        }

        private void ProcessGuess(string guess)
        {
            if (guess.Equals(this.NumberToGuess))
            {
                ProcessWin();
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

                // TODO: Extract to notifier.
                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);

                this.GuessAttempts++;
            }
        }

        private void ProcessCheat()
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

            // TODO: Extract to notifier.
            Console.WriteLine("The number looks like {0}.", this.CheatHelper);
        }

        private void ProcessWin()
        {
            this.Notifier.Notify("Win");

            if (!this.HasCheated)
            {
                this.Scoreboard.AddToScoreboard(this.GuessAttempts);
            }
        }

        public void Initialize()
        {
            this.Notifier.Notify("Introduction");
            this.Notifier.Notify("Commands");

            this.NumberToGuess = GenerateNumber(4);
            this.GuessAttempts = 1;

            this.CheatHelper = "XXXX";
            this.HasCheated = false;
        }

        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                isRunning = ReadAction();
            }
        }
    }
}
