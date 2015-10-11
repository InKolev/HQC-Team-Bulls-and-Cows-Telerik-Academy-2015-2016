
namespace BullsAndCows.Core
{
    using System;
    using Interfaces;
    using BullsAndCows.Helpers.Commands;

    internal class ActionsController : IController, IRunnable
    {
        public ActionsController(IDataState data, INotifier notifier, INumberGenerator numberGenerator, IScoreboard scoreboard, ICommandsFactory commandsFactory, IActionsReader reader)
        {
            this.Data = data;
            this.ActionsReader = reader;
            this.Notifier = notifier;
            this.Scoreboard = scoreboard;
            this.CommandsFactory = commandsFactory;
            this.NumberGenerator = numberGenerator;
        }

        public bool IsRunning { get; private set; }

        public IActionsReader ActionsReader { get; set; }

        public INotifier Notifier { get; set; }

        public IScoreboard Scoreboard { get; set; }

        public ICommandsFactory CommandsFactory { get; set; }

        public INumberGenerator NumberGenerator { get; set; }

        public IDataState Data { get; set; }

        public void ReadAction()
        {
            string input = String.Empty;

            this.Notifier.Notify("Enter your Guess/Command: ");

            input = this.ActionsReader.Read();

            var command = this.CommandsFactory.GetCommand(input);

            this.IsRunning = command.Execute();
        }

        public void Run()
        {
            this.CommandsFactory
                .GetCommand("start")
                .Execute();

            this.IsRunning = true;

            while (true)
            {
                while (this.IsRunning)
                {
                    this.ReadAction();
                }

                this.Notifier.Notify("Would you like to play again? \"y\" or \"n\" ");

                var answer = this.ActionsReader.Read();

                if (answer.Equals("y") || answer.Equals("Y"))
                {
                    Run();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
