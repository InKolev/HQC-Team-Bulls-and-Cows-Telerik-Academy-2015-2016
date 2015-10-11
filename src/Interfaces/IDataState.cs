// <copyright  file="IDataState.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IDataState
    {
        string CheatHelper { get; set; }

        string NumberToGuess { get; set; }

        bool HasCheated { get; set; }

        DateTime StartTime { get; set; }

        double PlayTime { get; set; }

        int GuessAttempts { get; set; }

        int GuessAttemptsMaxValue { get; set; }

        int Bulls { get; set; }

        int Cows { get; set; }
    }
}
