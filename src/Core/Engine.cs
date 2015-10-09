
namespace BullsAndCows.Core
{
    using Helpers;
    using Helpers.Misc;
    using Interfaces;

    internal class Engine : IEngine, IRunnable
    {
        public void Initialize()
        {
            this.Data = new Data();
            this.Notifier = new ConsoleNotifier();
            this.NumberGenerator = new RandomNumberGenerator();
            this.Scoreboard = new Scoreboard(this.Notifier, ScoreSerializer.GetSerializer());
            this.CommandsFactory = new CommandsFactory(this.Data, this.Notifier, this.NumberGenerator, this.Scoreboard);
            this.Controller = new ActionsController(this.Data, this.Notifier, this.NumberGenerator, this.Scoreboard, this.CommandsFactory);
        }

        public void Run()
        {
            this.Controller.Run();
        }

        public IDataState Data { get; set; }

        public IController Controller { get; set; }

        public IScoreboard Scoreboard { get; set; }

        public IScoreNotifier Notifier { get; set; }

        public INumberGenerator NumberGenerator { get; set; }

        public ICommandsFactory CommandsFactory { get; set; }
    }
}
