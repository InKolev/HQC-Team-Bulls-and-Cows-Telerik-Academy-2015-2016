// <copyright  file="Validator.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Validators
{
    using System;
    using System.Text.RegularExpressions;
    using Interfaces;

    /// <summary>
    /// The concrete implementation for IValidator interface.
    /// </summary>
    internal class Validator : IValidator
    {
        private static Validator instance;
        private static object syncLock = new object();

        protected Validator()
        {
        }

        public static Validator GetValidator()
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
            if (name.Length < 3 || name.Length > 50)
            {
                return false;
            }

            return !Regex.IsMatch(name, @"[^\w \d]");
        }
    }
}
