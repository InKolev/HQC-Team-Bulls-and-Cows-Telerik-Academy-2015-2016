// <copyright  file="EmptyCommand.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BullsAndCows.Interfaces;

    /// <summary>
    /// The concrete implementation of EmptyCommand for ICommand interface.
    /// </summary>
    internal class EmptyCommand : ICommand
    {

        /// <summary>
        /// The core logic for executing the Empty command - Null object.
        /// </summary>
        /// <returns>Returns</returns>
        public bool Execute()
        {
            return false;
        }
    }
}
