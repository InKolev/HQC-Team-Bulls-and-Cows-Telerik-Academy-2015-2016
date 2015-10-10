using BullsAndCows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Helpers.Readers
{
    internal class ConsoleReader : IActionsReader
    {
        public string Read()
        {
            var input = Console.ReadLine().Trim();

            return input;
        }
    }
}
