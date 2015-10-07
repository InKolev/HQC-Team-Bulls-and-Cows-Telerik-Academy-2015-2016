namespace BullsAndCows.Helpers
{
    using System;
    using System.Linq;
    using BullsAndCows.Interfaces;
    using BullsAndCows.Core;

    class ProcessGuessCommand : ICommand
    {
        public ProcessGuessCommand(Data data, INotifier notifier, string guess)
        {
            this.Data = data;
            this.Notifier = notifier;
            this.Guess = guess;
        }

        private Data Data { get; set; }

         private INotifier Notifier { get; set; }

        private string Guess { get; set; }

        public void Execute()
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

            var hasRepetitions = NumberHasRepetitions(this.Guess);

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
