namespace BullsAndCows.Interfaces
{
    using System.Collections.Generic;
    using Helpers;

    interface IScoreNotifier : INotifier
    {
        void DisplayScores(IList<Score> scores);
    }
}
