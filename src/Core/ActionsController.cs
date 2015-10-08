using System;
using BullsAndCows.Helpers;
using System.Text.RegularExpressions;
using BullsAndCows.Interfaces;

namespace BullsAndCows.Core
{
    internal class ActionsController : IController
    {
        public ActionsController(IDataState data, INotifier notifier, IScoreboard scoreboard, INumberGenerator numberGenerator, ICommandsFactory commandsFactory)
        {
            this.Data = data;
            this.Notifier = notifier;
            this.Scoreboard = scoreboard;
            this.CommandsFactory = commandsFactory;
            this.NumberGenerator = numberGenerator;
        }


        public INotifier Notifier { get; set; }

        public IScoreboard Scoreboard { get; set; }

        public ICommandsFactory CommandsFactory { get; set; }

        public INumberGenerator NumberGenerator { get; set; }

        public IDataState Data { get; set; }

        private bool ReadAction()
        {
            this.Notifier.Notify("Enter your Guess/Command: ");

            string input = Console.ReadLine().Trim();

            var command = this.CommandsFactory.GetCommand(input);

            bool isRunning = command.Execute();

            return isRunning;
        }

        public void Initialize()
        {
            this.Notifier.Notify("IntroductionCall");
            this.Notifier.Notify("CommandsCall");
            this.Notifier.Notify("New game started. Wish you luck.");

            this.Data.GuessAttemptsMaxValue = 25;
            this.Data.NumberToGuess = this.NumberGenerator.GenerateNumber(4);
            //Console.WriteLine(this.Data.NumberToGuess);
            this.Data.GuessAttempts = 1;

            this.Data.CheatHelper = "XXXX";
            this.Data.HasCheated = false;
        }

        public void Run()
        {
            Initialize();

            bool isRunning = true;

            while (true)
            {
                while (isRunning)
                {
                    isRunning = ReadAction();
                }

                this.Notifier.Notify("Would you like to play again? Type \"yes\" or \"no\" ");

                var answer = Console.ReadLine();

                if (answer.Equals("yes") || answer.Equals("YES"))
                {
                    Run();
                }
                else if (answer.Equals("no") || answer.Equals("NO"))
                {
                    break;
                }
            }
        }

    }
}
