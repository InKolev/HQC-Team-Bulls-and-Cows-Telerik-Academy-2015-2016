using BullsAndCows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Helpers
{
    internal class ConsoleNotifier : INotifier
    {
        private int WindowWidth { get; set; } = Console.WindowWidth;

        private void DisplayIntroductionMessage()
        {
            string welcomeMessage = "Welcome to “Bulls and Cows” game. Try to guess my secret 4-digit number. The digits inside the secret number cannot be repeated. Have fun!";

            Console.WriteLine(new String('*', this.WindowWidth - 1));
            Console.WriteLine(String.Format("{0} {1} {0}", new String('*', this.WindowWidth / 2 - welcomeMessage.Length / 2 - 2), welcomeMessage));
            Console.WriteLine(new String('*', this.WindowWidth - 1));
        }

        private void DisplayCommandsList()
        {
            Console.WriteLine("\"commands\" - to display the commands list.");
            Console.WriteLine("\"start\"    - to start a new game.");
            Console.WriteLine("\"exit\"     - to quit the game and close the application.");
            Console.WriteLine("\"help\"     - to unveil a random secret digit (if you want to be a cheater).");
            Console.WriteLine("\"top\"      - to view the top scoreboard.");
        }

        public void Notify(string message)
        {
            switch (message)
            {
                case "IntroductionCall":
                    {
                        DisplayIntroductionMessage();
                        break;
                    }
                case "CommandsCall":
                    {
                        DisplayCommandsList();
                        break;
                    }
                default:
                    {
                        Console.WriteLine(message);
                        break;
                    }
            }
        }
    }
}
