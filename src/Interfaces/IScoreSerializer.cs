namespace BullsAndCows.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Helpers;

    public interface IScoreSerializer
    {
        ICollection<Score> Load();

        void Save(ICollection<Score> data);
    }
}
