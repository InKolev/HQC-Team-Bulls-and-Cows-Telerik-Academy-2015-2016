using BullsAndCows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Helpers.Commands
{
    // For testing purposes.
    internal class EmptyCommand : ICommand
    {
        public bool Execute()
        {
            return false;
        }
    }
}
