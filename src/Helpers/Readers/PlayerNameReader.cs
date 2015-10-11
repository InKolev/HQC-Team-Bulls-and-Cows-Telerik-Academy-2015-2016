// <copyright  file="PlayerNameReader.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Readers
{
    using System;
    using BullsAndCows.Interfaces;
    using BullsAndCows.Helpers.Validators;
    using BullsAndCows.Helpers;

    /// <summary>
    /// Class for reading the player's name
    /// </summary>
    internal class PlayerNameReader : IActionsReader
    {
        private const string InvalidNameMessage = "Name should be between 3 and 50 characters long and contain only latin letters, digits and space! Please choose another name.";

        public PlayerNameReader()
            : this(Validator.GetValidator(), new ConsoleNotifier())
        {
        }

        public PlayerNameReader(IValidator validator, INotifier notifier)
        {
            this.InputValidator = validator;
            this.Notifier = notifier;
        }

        private IValidator InputValidator { get; set; }

        private INotifier Notifier { get; set; }

        /// <summary>
        /// Reads the player's name
        /// </summary>
        /// <returns>String input</returns>
        public string Read()
        {
            string input = Console.ReadLine().Trim();

            while (true)
            {
                if (this.InputValidator.ValidateName(input))
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