using Moq;
using NUnit.Framework;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Abstractions;
using UnitTestExample.Controllers;
using UnitTestExample.Entities;

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
            var valtozo = new Mock<IAccountManager>(MockBehavior.Strict);
            valtozo
                .Setup(m => m.CreateAccount(It.IsAny<Account>()))
                .Returns<Account>(a => a);
            accountController.AccountManager = valtozo.Object;
            


            //Act

            var asd = accountController.Register(email, password);

            //Assert
            Assert.AreEqual(email, asd.Email);
            Assert.AreEqual(password, asd.Password);
            Assert.AreNotEqual(Guid.Empty, asd.ID);
            valtozo.Verify(m => m.CreateAccount(asd), Times.Once);
        }
        [ Test,
             TestCase("isds@sdsds.hu", "Asdfd1234234"),
    TestCase("isfds.u123inus.hu", "Abcd12311234"),
    TestCase("irf@uni-corvinus.hu", "abcd1234"),
    TestCase("irf@uni-corvinus.hu", "ABCD1234"),
    TestCase("irf@uni-corvinus.hu", "abcdABCD"),
    TestCase("irf@uni-corvinus.hu", "Ab1234")
            ]
        public void TestRegisterValidateException(string email, string password)
        { 
            //Arrange
            var accountController = new AccountController();
           
            //Act
            try
            {
                var asd = accountController.Register(email, password);
                Assert.Fail();

            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ValidationException>(ex);

            }
           


        }


        [
    Test,
    TestCase("irf@uni-corvinus.hu", "Abcd1234")
]
        public void TestRegisterApplicationException(string newEmail, string newPassword)
        {
            // Arrange
            var accountServiceMock = new Mock<IAccountManager>(MockBehavior.Strict);
            accountServiceMock
                .Setup(m => m.CreateAccount(It.IsAny<Account>()))
                .Throws<ApplicationException>();
            var accountController = new AccountController();
            accountController.AccountManager = accountServiceMock.Object;

            // Act
            try
            {
                var actualResult = accountController.Register(newEmail, newPassword);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ApplicationException>(ex);
            }

            // Assert
        }

    }
}
