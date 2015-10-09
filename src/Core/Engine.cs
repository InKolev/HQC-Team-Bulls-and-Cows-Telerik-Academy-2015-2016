
namespace BullsAndCows.Core
{
    using Helpers;
    using Helpers.Misc;
    using Interfaces;

    internal class Engine
    {
        public static void Main()
        {
            IDataState data = new Data();
            IScoreNotifier notifier = new ConsoleNotifier();
            INumberGenerator numberGenerator = new RandomNumberGenerator();
            IScoreboard scoreboard = new Scoreboard(notifier, ScoreSerializer.GetSerializer());
            ICommandsFactory commandsFactory = new CommandsFactory(data, notifier, numberGenerator, scoreboard);
            IController actionsController = new ActionsController(data, notifier, scoreboard, numberGenerator, commandsFactory);

            var bullsAndCows = new Game(actionsController);
            bullsAndCows.Start();
        }
    }
}
