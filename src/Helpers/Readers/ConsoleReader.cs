using BullsAndCows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Helpers.Readers
{
    internal class ConsoleReader : IActionsReader
    {
        public void Read(out string input)
        {
            input = Console.ReadLine().Trim();
        }
    }
}
