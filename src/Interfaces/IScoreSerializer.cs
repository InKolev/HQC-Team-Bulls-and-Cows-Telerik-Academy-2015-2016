namespace BullsAndCows.Interfaces
{
    using System.Collections.Generic;

    using Helpers;

    public interface IScoreSerializer
    {
        List<Score> Load();

        void Save(List<Score> data);
    }
}
