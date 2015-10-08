using BullsAndCows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Helpers.Commands
{
    internal class DisplayMessageCommand : ICommand
    {
        public DisplayMessageCommand(INotifier notifier,bool returnValue, string message)
        {
            this.Notifier = notifier;
            this.Message = message;
            this.ReturnValue = returnValue;
        }

        public bool ReturnValue { get; private set; }

        public string Message { get; private set; }

        public INotifier Notifier { get; private set; }

        public bool Execute()
        {
            this.Notifier.Notify(this.Message);
            return this.ReturnValue;
        }
    }
}
