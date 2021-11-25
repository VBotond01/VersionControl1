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





    }
}
