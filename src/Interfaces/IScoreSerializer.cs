// <copyright  file="IScoreSerializer.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Interfaces
{
    using System.Collections.Generic;

    using Helpers;

    public interface IScoreSerializer
    {
        IList<Score> Load();

        void Save(IList<Score> data);
    }
}
