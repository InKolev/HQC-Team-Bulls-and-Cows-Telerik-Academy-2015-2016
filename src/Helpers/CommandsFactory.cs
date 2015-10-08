using BullsAndCows.Helpers.Commands;
using BullsAndCows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BullsAndCows.Helpers
{
    internal class CommandsFactory : ICommandsFactory
    {
        public CommandsFactory(IDataState data, INotifier notifier, INumberGenerator numberGenerator, IScoreboard scoreboard)
        {
            this.Data = data;
            this.Notifier = notifier;
            this.Scoreboard = scoreboard;
            this.NumberGenerator = numberGenerator;
            this.FourDigitNumberPattern = new Regex("[0-9][0-9][0-9][0-9]");
        }

        public IDataState Data { get; private set; }

        public INotifier Notifier { get; private set; }

        public INumberGenerator NumberGenerator { get; private set; }

        public IScoreboard Scoreboard { get; private set; }

        private Regex FourDigitNumberPattern { get; set; }

        public ICommand GetCommand(string command)
        {
            ICommand commandExecutor = null;

            switch (command)
            {
                case "help":
                    {
                        commandExecutor = new CheatCommand(this.Data, this.Notifier, this.NumberGenerator);
                        break;
                    }
                case "start":
                    {
                        commandExecutor = new InitializeGameCommand(this.Data, this.Notifier, this.NumberGenerator);
                        break;
                    }
                case "commands":
                    {
                        commandExecutor = new DisplayCommandsListCommand(this.Notifier);
                        break;
                    }
                case "top":
                    {
                        commandExecutor = new DisplayScoreboardCommand(this.Scoreboard);
                        break;
                    }
                case "exit":
                    {
                        commandExecutor = new QuitGameCommand(this.Notifier);
                        break;
                    }
                default:
                    {
                        commandExecutor = ProcessGuessAndReturnAppropriateCommand(command);
                        break;
                    }
            }

            return commandExecutor;
        }

        private ICommand ProcessGuessAndReturnAppropriateCommand(string command)
        {
            ICommand commandExecutor = null;

            if (this.FourDigitNumberPattern.IsMatch(command) && (command.Length == 4))
            {
                if (this.Data.GuessAttempts <= this.Data.GuessAttemptsMaxValue)
                {
                    if (command.Equals(this.Data.NumberToGuess))
                    {
                        commandExecutor = new WinGameCommand(this.Notifier, this.Scoreboard, this.Data);
                    }
                    else
                    {
                        commandExecutor = new GuessCommand(this.Data, this.Notifier, command);
                    }
                }
                else
                {
                    commandExecutor = new DisplayMessageCommand(this.Notifier, false, "You have reached the maximum guess limit. You can't even finish a Bulls And Cows game. You are as dumb as you look...");
                }
            }
            else
            {
                commandExecutor = new DisplayMessageCommand(this.Notifier, true, "Please enter a 4-digit number or one of the commands: ");
            }

            return commandExecutor;
        }
    }
}
