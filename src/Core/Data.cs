// <copyright  file="Data.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Core
{
    using System;
    using BullsAndCows.Interfaces;

    internal class Data : IDataState
    {
        public string CheatHelper { get; set; }

        public string NumberToGuess { get; set; }

        public bool HasCheated { get; set; }

        public int GuessAttempts { get; set; }

        public int GuessAttemptsMaxValue { get; set; }

        public int Bulls { get; set; }

        public int Cows { get; set; }

        public DateTime StartTime { get; set; }
        
        public double PlayTime { get; set; }        
    }
}
