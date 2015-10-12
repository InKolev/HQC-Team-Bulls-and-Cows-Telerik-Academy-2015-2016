// <copyright  file="GuessCommand.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Commands
{
    using System;
    using System.Linq;
    using Interfaces;

    /// <summary>
    /// The core implementation for GuessComand of the ICommand interface.
    /// </summary>
    internal class GuessCommand : ICommand
    {
        private const string IncorrectInputMessage = "Incorrect number. The guess cannot contain repeatable digits.";

        public GuessCommand(IDataState data, INotifier notifier, string guess)
        {
            this.Data = data;
            this.Notifier = notifier;
            this.Guess = guess;
        }

        private IDataState Data { get; set; }

        private INotifier Notifier { get; set; }

        private string Guess { get; set; }

        /// <summary>
        /// The core logic for executing a guess command.
        /// </summary>
        /// <returns>Returns a bollean value - true</returns>
        public bool Execute()
        {
            this.Data.Bulls = 0;
            this.Data.Cows = 0;

            for (int i = 0; i < this.Data.NumberToGuess.Length; i++)
            {
                if (this.Data.NumberToGuess[i].Equals(this.Guess[i]))
                {
                    this.Data.Bulls++;
                }
                else if (this.Data.NumberToGuess.Contains(this.Guess[i]))
                {
                    this.Data.Cows++;
                }
            }

            var hasRepetitions = this.NumberHasRepetitions(this.Guess);

            if (hasRepetitions)
            {
                this.Notifier.Notify(IncorrectInputMessage);
            }
            else
            {
                this.Data.GuessAttempts++;
                this.Notifier.Notify(string.Format("Wrong number! Bulls: {0}, Cows: {1}", this.Data.Bulls, this.Data.Cows));
            }

            return true;
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
    }
}
