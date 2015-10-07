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
        public ActionsController(Data data, INotifier notifier, IScoreboard scoreboard, INumberGenerator numberGenerator)
        {
            this.Data = data;
            this.Notifier = notifier;
            this.Scoreboard = scoreboard;
            this.NumberGenerator = numberGenerator;
            this.FourDigitNumberPattern = new Regex("[0-9][0-9][0-9][0-9]");
        }

        private Regex FourDigitNumberPattern { get; set; }

        private INotifier Notifier { get; set; }

        private IScoreboard Scoreboard { get; set; }

        private INumberGenerator NumberGenerator { get; set; }

        private Data Data { get; set; }


        private bool ReadAction()
        {
            this.Notifier.Notify("Enter your Guess or a Command to be executed: ");

            string input = Console.ReadLine().Trim();

            switch (input)
            {
                case "start":
                    {
                        Initialize();
                        break;
                    }
                case "help":
                    {
                        ProcessCheat();
                        break;
                    }
                case "top":
                    {
                        this.Scoreboard.DisplayTopScores();
                        break;
                    }
                case "commands":
                    {
                        this.Notifier.Notify("CommandsCall");
                        break;
                    }
                case "exit":
                    {
                        this.Notifier.Notify("Exiting game.");
                        return false;
                    }
                default:
                    {
                        if (this.FourDigitNumberPattern.IsMatch(input) && (input.Length == 4))
                        {
                            if (this.Data.GuessAttempts <= this.Data.GuessAttemptsMaxValue)
                            {
                                bool isRunning = ProcessGuess(input);

                                return !(isRunning);
                            }
                            else
                            {
                                this.Notifier.Notify("You have reached the maximum guess limit. You can't even finish a Bulls And Cows game. You are as dumb as you look...");
                                return false;
                            }
                        }
                        else
                        {
                            this.Notifier.Notify("Please enter a 4-digit number or one of the commands: ");
                        }

                        break;
                    }
            }

            return true;
        }

        private bool FourDigitNumberHasRepeatingDigits(string number)
        {
            foreach (var digit in number)
            {
            }
            return true;
        }

        private bool ProcessGuess(string guess)
        {
            if (guess.Equals(this.Data.NumberToGuess))
            {
                ProcessWin();
                return true;
            }
            else
            {
                this.Data.Bulls = 0;
                this.Data.Cows = 0;

                for (int i = 0; i < this.Data.NumberToGuess.Length; i++)
                {
                    if (this.Data.NumberToGuess[i].Equals(guess[i]))
                    {
                        this.Data.Bulls++;
                    }
                    else if (this.Data.NumberToGuess.Contains(guess[i]))
                    {
                        this.Data.Cows++;
                    }
                }

                var hasRepetitions = NumberHasRepetitions(guess);
            
                if (hasRepetitions)
                {
                    this.Notifier.Notify("Incorrect number. The guess cannot contain repeatable digits.");
                }
                else
                {
                    this.Data.GuessAttempts++;
                    this.Notifier.Notify(String.Format("Wrong number! Bulls: {0}, Cows: {1}", this.Data.Bulls, this.Data.Cows));
                }
            }

            return false;
        }

        private bool NumberHasRepetitions(string guess)
        {
            int[] repeatedDigits = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < this.Data.NumberToGuess.Length; i++)
            {
                var position = int.Parse(guess[i].ToString());

                if (guess.Contains(guess[i]))
                {
                    repeatedDigits[position]++;
                }
            }

            return repeatedDigits.Any(x => x > 1);
        }

        private void ProcessCheat()
        {
            this.Data.HasCheated = true;

            if (this.Data.CheatHelper.Contains('X'))
            {
                int i;

                do
                {
                    i = this.NumberGenerator.Next(0, 4);
                }
                while (this.Data.CheatHelper[i] != 'X');

                char[] cheatHelperChars = this.Data.CheatHelper.ToCharArray();
                cheatHelperChars[i] = this.Data.NumberToGuess.ToString()[i];
                this.Data.CheatHelper = new string(cheatHelperChars);
            }

            this.Notifier.Notify(String.Format("The number looks like {0}.", this.Data.CheatHelper));
        }

        private void ProcessWin()
        {
            this.Notifier.Notify("Congratulations! You have guessed the secret number.");

            if (!this.Data.HasCheated)
            {
                this.Scoreboard.AddToScoreboard(this.Data.GuessAttempts);
            }
        }

        public void Initialize()
        {
            this.Notifier.Notify("IntroductionCall");
            this.Notifier.Notify("CommandsCall");
            this.Notifier.Notify("New game started. Wish you luck.");
            this.Data.GuessAttemptsMaxValue = 25;
            this.Data.NumberToGuess = this.NumberGenerator.GenerateNumber(4);
            //Console.WriteLine(this.Data.NumberToGuess);
            this.Data.GuessAttempts = 1;

            this.Data.CheatHelper = "XXXX";
            this.Data.HasCheated = false;
        }

        public void Run()
        {
            Initialize();

            bool isRunning = true;

            while (true)
            {
                while (isRunning)
                {
                    isRunning = ReadAction();
                }

                this.Notifier.Notify("Would you like to play again? Type \"yes\" or \"no\" ");

                var answer = Console.ReadLine();

                if (answer.Equals("yes") || answer.Equals("YES"))
                {
                    Run();
                }
                else if (answer.Equals("no") || answer.Equals("NO"))
                {
                    break;
                }
            }
        }
    }
}
