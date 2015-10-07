using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Interfaces
{
    public interface IDataState
    {
        string CheatHelper { get; set; }

        string NumberToGuess { get; set; }

        bool HasCheated { get; set; }

        int GuessAttempts { get; set; }

        int GuessAttemptsMaxValue { get; set; }

        int Bulls { get; set; }

        int Cows { get; set; }
    }
}
