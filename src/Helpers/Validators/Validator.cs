// <copyright  file="ConsoleReader.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Validators
{
    using System;
    using Interfaces;

    internal class Validator : IValidator
    {
        private static Validator instance;
        private static object syncLock = new object();

        protected Validator()
        {

        }

        public Validator GetInstance()
        {
            if (instance == null)
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                        instance = new Validator();
                    }
                }
            }

            return instance;
        }

        public bool ValidateName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
