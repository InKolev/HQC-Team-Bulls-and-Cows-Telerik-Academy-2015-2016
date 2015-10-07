namespace BullsAndCows.Helpers
{
    using System;
    using System.Linq;
    using BullsAndCows.Interfaces;
    using BullsAndCows.Core;

    class ProcessCheatCommand : ICommand
    {
        public ProcessCheatCommand(Data data, INotifier notifier, INumberGenerator numberGenerator)
        {
            this.Data = data;
            this.Notifier = notifier;
            this.NumberGenerator = numberGenerator;
        }

        private Data Data { get; set; }

         private INotifier Notifier { get; set; }

         private INumberGenerator NumberGenerator { get; set; }

        public void Execute()
        {
            this.Data.HasCheated = true;

            if (this.Data.CheatHelper.Contains('X'))
            {
                int i;

                do
                {
                    i = this.NumberGenerator.Next(0, 4);
                }
                while (this.Data.CheatHelper[i] != 'X');

                char[] cheatHelperChars = this.Data.CheatHelper.ToCharArray();
                cheatHelperChars[i] = this.Data.NumberToGuess.ToString()[i];
                this.Data.CheatHelper = new string(cheatHelperChars);
            }

            this.Notifier.Notify(String.Format("The number looks like {0}.", this.Data.CheatHelper));
        }
    }
}
