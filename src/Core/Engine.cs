using BullsAndCows.Helpers;
using BullsAndCows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Core
{
    internal class Engine
    {
        public static void Main()
        {
            var data = new Data();
            var notifier = new ConsoleNotifier();
            IScoreboard scoreboard = new Scoreboard(notifier, new ScoreSerializer());
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            IController actionsController = new ActionsController(data, notifier, scoreboard, numberGenerator);

            var bullsAndCows = new Game(actionsController);
            bullsAndCows.Start();
        }
    }
}
