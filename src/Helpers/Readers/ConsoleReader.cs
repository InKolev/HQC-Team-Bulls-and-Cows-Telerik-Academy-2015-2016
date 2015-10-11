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

    /// <summary>
    /// Class for reading from the console
    /// </summary>
    internal class ConsoleReader : IActionsReader
    {
        /// <summary>
        /// Reads from the console
        /// </summary>
        /// <returns>String input</returns>
        public string Read()
        {
            var input = Console.ReadLine().Trim();

            return input;
        }
    }
}
