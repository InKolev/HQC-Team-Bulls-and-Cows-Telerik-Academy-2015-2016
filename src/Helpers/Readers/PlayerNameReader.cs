// <copyright  file="ConsoleReader.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Readers
{
    using System;
    using BullsAndCows.Interfaces;
    using BullsAndCows.Helpers.Validators;
    using BullsAndCows.Helpers;

    internal class PlayerNameReader : IActionsReader
    {
        private const string InvalidNameMessage = "Name should be between 3 and 50 characters long! Please choose another name.";
        private IValidator Validator { get; set; }
        private INotifier Notifier { get; set; }

        public string Read()
        {
            string input = Console.ReadLine().Trim(); 

            while (true)
            {
                if (this.Validator.ValidateName(input))
                {
                    break;
                }
                else
                {
                    this.Notifier.Notify(InvalidNameMessage);
                    input = Console.ReadLine().Trim();
                }
            }

            return input;
        }
    }
}