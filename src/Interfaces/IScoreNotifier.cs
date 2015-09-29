namespace BullsAndCows.Interfaces
{
    using System.Collections.Generic;
    using Helpers;

    interface IScoreNotifier : INotifier
    {
        void DisplayScores(List<Score> scores);
    }
}
