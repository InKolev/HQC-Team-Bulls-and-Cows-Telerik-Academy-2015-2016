using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    internal class GameEngine
    {

        public int NumberToGuess { get; set; }

        public int GuessAttempts { get; set; }

        public bool HasCheated { get; set; }

        public string CheatHelper { get; set; }
    }
}
