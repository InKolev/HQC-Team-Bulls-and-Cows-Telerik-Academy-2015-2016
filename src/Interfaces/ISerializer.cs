namespace BullsAndCows.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface ISerializer
    {
        IList<IComparable> Load();

        void Save(IList<IComparable> stuff);
    }
}
