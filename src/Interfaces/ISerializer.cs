using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Interfaces
{
    interface ISerializer
    {
        SortedList<int, string> Load();

        void Save(SortedList<int, string> scores);
    }
}
