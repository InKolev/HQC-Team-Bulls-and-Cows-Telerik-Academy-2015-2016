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
            IDataState data = new Data();
            IScoreNotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            IScoreboard scoreboard = new Scoreboard(notifier, new ScoreSerializer());
            ICommandsFactory commandsFactory = new CommandsFactory(data, notifier, numberGenerator, scoreboard);
            IController actionsController = new ActionsController(data, notifier, scoreboard, numberGenerator, commandsFactory);

            var bullsAndCows = new Game(actionsController);
            bullsAndCows.Start();
        }
    }
}
