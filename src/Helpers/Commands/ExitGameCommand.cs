using BullsAndCows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BullsAndCows.Helpers.Commands
{ 
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

            //Thread.Sleep(500);
            //Environment.Exit(0);

            return false;
        }
    }
}
