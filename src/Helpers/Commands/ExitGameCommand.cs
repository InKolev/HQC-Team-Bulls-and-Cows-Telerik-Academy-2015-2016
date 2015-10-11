// <copyright  file="ExitGameCommand.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using BullsAndCows.Interfaces;

    internal class ExitGameCommand : ICommand
    {
        public ExitGameCommand(INotifier notifier)
        {
            this.Notifier = notifier;
        }

        public INotifier Notifier { get; private set; }

        public bool Execute()
        {
            this.Notifier.Notify("Exitting game...");

            return false;
        }
    }
}
