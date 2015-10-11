// <copyright  file="CheatCommand.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Commands
{
    using System;
    using System.Linq;
    using BullsAndCows.Interfaces;
    using BullsAndCows.Core;

    internal class CheatCommand : ICommand
    {
        public CheatCommand(IDataState data, INotifier notifier, INumberGenerator numberGenerator)
        {
            this.Data = data;
            this.Notifier = notifier;
            this.NumberGenerator = numberGenerator;
        }

        private IDataState Data { get; set; }

        private INotifier Notifier { get; set; }

        private INumberGenerator NumberGenerator { get; set; }

        public bool Execute()
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

            this.Notifier.Notify(string.Format("The number looks like {0}.", this.Data.CheatHelper));

            return true;
        }
    }
}
