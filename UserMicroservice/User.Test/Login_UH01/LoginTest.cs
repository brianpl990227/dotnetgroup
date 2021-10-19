using System;
using Xunit;
using Moq;
using User.Infraestructure.Services.LoginService;
using User.Domain.DtoIn;
using User.Infraestructure.Services.CacheService;
using User.Infraestructure.Services.UserService;
using User.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace User.Test.Login_UH01
{
    public class LoginTest
    {
        [Fact]
        public void Login_Ok_Test()
        {
            //Arrange
            LoginDto loginDto = new LoginDto()
            {
                Email = "brianpl",
                Password = "12345"
            };
            var mockLoginService = new Mock<ILoginService>();
            mockLoginService.Setup(login => login.SignIn(loginDto)).Returns("12312312312edq3ewsdfr313r3q25r2354");
            var mockCacheService = new Mock<ICacheService>();          
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(user => user.isItBlocked(loginDto.Email)).Returns(false);
            var controller = new AuthController(mockLoginService.Object, mockCacheService.Object, mockUserService.Object);

            //Act
            var actionResult = controller.Login(loginDto);

            //Assert
            var ok = actionResult as OkObjectResult;
           
            Assert.Equal("12312312312edq3ewsdfr313r3q25r2354", ok.Value);
            Assert.IsType<OkObjectResult>(ok);
        }

        [Fact]
        public void Unauthorized_Test()
        {
            //Arrange
            LoginDto loginDto = new LoginDto()
            {
                Email = "brianpl",
                Password = "12345"
            };
            var mockLoginService = new Mock<ILoginService>();
            var mockCacheService = new Mock<ICacheService>();
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(user => user.isItBlocked(loginDto.Email)).Returns(true);
            var controller = new AuthController(mockLoginService.Object, mockCacheService.Object, mockUserService.Object);

            //Act
            var actionResult = controller.Login(loginDto);


            //Assert
            Assert.IsType<UnauthorizedResult>(actionResult);

        }

        [Fact]
        public void Block_Account_Test()
        {
            //Arrange
            LoginDto loginDto = new LoginDto()
            {
                Email = "brianpl",
                Password = "12345"
            };

            var mockLoginService = new Mock<ILoginService>();
            var mockCacheService = new Mock<ICacheService>();
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(user => user.isItBlocked(loginDto.Email)).Returns(false);
            mockLoginService.Setup(login => login.SignIn(loginDto)).Returns("");
            mockCacheService.Setup(cache => cache.CountLoginFailed(loginDto.Email)).Returns(true);
            var controller = new AuthController(mockLoginService.Object, mockCacheService.Object, mockUserService.Object);

            //Act
            var actionResult = controller.Login(loginDto);

            //Assert
            Assert.IsType<UnauthorizedResult>(actionResult);
        }

        [Fact]
        public void Login_Failed_Test()
        {
            //Arrange
            LoginDto loginDto = new LoginDto()
            {
                Email = "brianpl",
                Password = "12345"
            };

            var mockLoginService = new Mock<ILoginService>();
            var mockCacheService = new Mock<ICacheService>();
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(user => user.isItBlocked(loginDto.Email)).Returns(false);
            mockLoginService.Setup(login => login.SignIn(loginDto)).Returns("");
            mockCacheService.Setup(cache => cache.CountLoginFailed(loginDto.Email)).Returns(false);
            var controller = new AuthController(mockLoginService.Object, mockCacheService.Object, mockUserService.Object);

            //Act
            var actionResult = controller.Login(loginDto);

            //Assert
            Assert.IsType<BadRequestResult>(actionResult);
        }



    }
}
