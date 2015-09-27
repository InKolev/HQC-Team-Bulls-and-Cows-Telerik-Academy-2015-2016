using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Interfaces
{
    interface IScoreboard
    {
        void DisplayTopScores();

        void AddToScoreboard(int guessAttempts);
    }
}
