using BullsAndCows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Helpers.Commands
{
    internal class DisplayCommandsListCommand : ICommand
    {
        public INotifier Notifier { get; private set; }

        public DisplayCommandsListCommand(INotifier notifier)
        {
            this.Notifier = notifier;
        }

        public bool Execute()
        {
            this.Notifier.Notify("CommandsCall");

            return true;
        }
    }
}
