﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Interfaces
{
    public interface IActionsReader
    {
        void Read(out string input);
    }
}
