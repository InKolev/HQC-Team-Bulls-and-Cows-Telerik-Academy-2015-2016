using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Interfaces
{
    public interface IEngine
    {
        IDataState Data { get; set; }

        IController Controller { get; set; }

        IScoreboard Scoreboard { get; set; }

        IScoreNotifier Notifier { get; set; }

        INumberGenerator NumberGenerator { get; set; }

        ICommandsFactory CommandsFactory { get; set; }
    }
}
