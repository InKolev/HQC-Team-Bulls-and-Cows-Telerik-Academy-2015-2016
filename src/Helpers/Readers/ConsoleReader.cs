// <copyright  file="ConsoleReader.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Readers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BullsAndCows.Interfaces;

    internal class ConsoleReader : IActionsReader
    {
        public string Read()
        {
            var input = Console.ReadLine().Trim();

            return input;
        }
    }
}
