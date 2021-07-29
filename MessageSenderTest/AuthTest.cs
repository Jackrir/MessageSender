using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PresentationLayer.API.Requests;
using PresentationLayer.Controllers;
using System.Threading.Tasks;

namespace MessageSenderTest
{
    [TestClass]
    public class AuthTest
    {

        [TestMethod]
        public async Task LogInSendBadModelReturnBadRequest()
        {
            //Arrange
            var mockService = new Mock<IAuthService>();
            var mockMapper = new Mock<IMapper>();
            AuthController controller = new AuthController(mockService.Object, mockMapper.Object);
            controller.ModelState.AddModelError("test", "test");

            //Act
            IActionResult result = await controller.LogIn(new LoginModelRequest());

            //Assert
            Assert.AreEqual(result.GetType(), typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task LogInSendUnknownUserReturnNoContent()
        {
            //Arrange
            var mockService = new Mock<IAuthService>();
            var mockMapper = new Mock<IMapper>();
            AuthController controller = new AuthController(mockService.Object, mockMapper.Object);

            //Act
            IActionResult result = await controller.LogIn(new LoginModelRequest() { Login = "ANSDibaykbsdfj", Password = "IBYBUIYOGBYIBHIUASDNL:" });

            //Assert
            Assert.AreEqual(result.GetType(), typeof(NoContentResult));
        }
    }
}
