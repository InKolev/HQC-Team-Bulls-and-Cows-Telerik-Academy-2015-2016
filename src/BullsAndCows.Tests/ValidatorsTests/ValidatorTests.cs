using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows.Helpers.Validators;

namespace BullsAndCows.Tests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void GetValidatorShouldReturnOnlyOneInstance()
        {
            var validator = Validator.GetValidator();
            var secondValidator = Validator.GetValidator();

            Assert.AreSame(validator, secondValidator);
        }
    }
}
