using ChurchSchool.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChurchSchool.Test
{
    [TestClass]
    public class EmailValidationTest
    {
        [TestMethod]
        public void ShouldValidateAValidEmail()
        {
            var email = new Email { Address = "gustavotesteemai09876543211@email.com" };

            Assert.IsTrue(email.IsValid());            
        }

        [TestMethod]
        public void ShouldNotValidateAnInvalidEmail()
        {
            //keep in mind with possible 'wrong validations' provided by mailaddress class. 
            var email = new Email { Address = "gustavotesteemai09876543211email" };

            Assert.IsFalse(email.IsValid());
        }
    }
}
