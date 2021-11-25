using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    class AccountControllerTestFicture
    {
        [Test,
            TestCase("sdfsd123",false),
            TestCase("fsf@asdfs",false),
            TestCase("sdfds.hu",false),
            TestCase("sdfsd@sdfsdf.hu",true)
            


            ]
        
        public void TestValidateEmail(string email, bool expectedResult)
        {
            //Arrange
            var accountController = new AccountController();



            //Act

            var valtozo = accountController.ValidateEmail(email);

            //Assert
            Assert.AreEqual(expectedResult,valtozo);




        }
        [Test,
            TestCase("sfasdf", false),
            TestCase("ASD",false),
            TestCase("AasdAdsa",false),
            TestCase("asdsA2",true)


            ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            //Arrange
            var accountController = new AccountController();



            //Act

            var valtozo = accountController.ValidateEmail(password);

            //Assert
            Assert.AreEqual(expectedResult, valtozo);

        }
        [Test,
            TestCase("sfdsf@sdfsd.hu", "Abcsdf324"),
            TestCase("adasd@sdfsd.hu","AsdsAi3423")
            ]
        public void TestRegisterHappyPath(string email, string password)
        {
            //Arrange
            var accountController = new AccountController();



            //Act

            var valtozo = accountController.Register(email, password);

            //Assert
            Assert.AreEqual(email, valtozo.Email);
            Assert.AreEqual(password, valtozo.Password);
            Assert.AreNotEqual(Guid.Empty, valtozo.ID);
        }



    }
}
