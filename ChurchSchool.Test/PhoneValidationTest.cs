using ChurchSchool.Domain.Structs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChurchSchool.Test
{
    [TestClass]
    public class PhoneValidationTest
    {
        [TestMethod]
        public void ShouldValidateAValidNumber()
        {
            Phone phoneNumber = new Phone { AreaCode = "24", Number = "22317987" };

            Assert.IsTrue(phoneNumber.ValidateBrazilianNumber());
            Assert.IsTrue(phoneNumber.ValidateBrazilianNumber("(24) 98816-4277"));
        }

        [TestMethod]
        public void ShouldNotValidateAnInvalidNumber()
        {
            Phone phoneNumber = new Phone { AreaCode = "aaa", Number = "" };

            Assert.IsFalse(phoneNumber.ValidateBrazilianNumber());
            Assert.IsFalse(phoneNumber.ValidateBrazilianNumber("zzzzzzzz"));
        }
    }
}
