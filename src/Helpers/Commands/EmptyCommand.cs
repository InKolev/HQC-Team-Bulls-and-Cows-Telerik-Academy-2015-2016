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

    internal class EmptyCommand : ICommand
    {
        public bool Execute()
        {
            return false;
        }
    }
}
