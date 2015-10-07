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
            this.FourDigitNumberPattern = new Regex("[1-9][0-9][0-9][0-9]");
            this.GuessAttemptsMaxValue = 25;
            this.randomNumberGenerator = new RandomNumberGenerator();
        }

        private Regex FourDigitNumberPattern { get; set; }

        private INotifier Notifier { get; set; }

        private IScoreboard Scoreboard { get; set; }

        private string CheatHelper { get; set; }

        private string NumberToGuess { get; set; }

        private bool HasCheated { get; set; }

        private int GuessAttempts { get; set; }

        private int GuessAttemptsMaxValue { get; set; }

        private RandomNumberGenerator randomNumberGenerator { get; set; }

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
                            if (this.GuessAttempts <= this.GuessAttemptsMaxValue)
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
            if (guess.Equals(this.NumberToGuess))
            {
                ProcessWin();
                return true;
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

                var hasRepetitions = NumberHasRepetitions(guess);
            
                if (hasRepetitions)
                {
                    this.Notifier.Notify("Incorrect number. The guess cannot contain repeatable digits.");
                }
                else
                {
                    this.GuessAttempts++;
                    this.Notifier.Notify(String.Format("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows));
                }
            }

            return false;
        }

        private bool NumberHasRepetitions(string guess)
        {
            int[] repeatedDigits = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < this.NumberToGuess.Length; i++)
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
            this.HasCheated = true;

            if (this.CheatHelper.Contains('X'))
            {
                int i;

                do
                {
                    i = this.randomNumberGenerator.Next(0, 4);
                }
                while (this.CheatHelper[i] != 'X');

                char[] cheatHelperChars = this.CheatHelper.ToCharArray();
                cheatHelperChars[i] = this.NumberToGuess.ToString()[i];
                this.CheatHelper = new string(cheatHelperChars);
            }

            this.Notifier.Notify(String.Format("The number looks like {0}.", this.CheatHelper));
        }

        private void ProcessWin()
        {
            this.Notifier.Notify("Congratulations! You have guessed the secret number.");

            if (!this.HasCheated)
            {
                this.Scoreboard.AddToScoreboard(this.GuessAttempts);
            }
        }

        public void Initialize()
        {
            this.Notifier.Notify("IntroductionCall");
            this.Notifier.Notify("CommandsCall");
            this.Notifier.Notify("New game started. Wish you luck.");

            this.NumberToGuess = randomNumberGenerator.GenerateNumber(4);
            Console.WriteLine(this.NumberToGuess);
            this.GuessAttempts = 1;

            this.CheatHelper = "XXXX";
            this.HasCheated = false;
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
