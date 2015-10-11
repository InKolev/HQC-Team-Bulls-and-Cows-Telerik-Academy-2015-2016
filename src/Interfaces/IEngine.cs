// <copyright  file="IEngine.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
