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

        [TestMethod]
        public void ValidatorShouldReturnTrueWithValidParameter()
        {
            var validator = Validator.GetValidator();
            var validation = validator.ValidateName("John Doe 42");

            Assert.IsTrue(validation);
        }

        [TestMethod]
        public void ValidatorShouldReturnFalseWithInvalidParameter()
        {
            var validator = Validator.GetValidator();
            var validation = validator.ValidateName("John Doe %");

            Assert.IsFalse(validation);
        }

        [TestMethod]
        public void ValidatorShouldReturnFalseWithInvalidStringLength()
        {
            var validator = Validator.GetValidator();
            var validation = validator.ValidateName("Jo");
            var anotherValidation = validator.ValidateName(new string('a', 51));

            Assert.IsFalse(validation);
            Assert.IsFalse(anotherValidation);
        }
    }
}
