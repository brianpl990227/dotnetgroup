using System;
using Xunit;
using Moq;
using User.Infraestructure.Repositories;
using User.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using User.Domain.Repositories.Auth;
using User.Domain.Auth.Login;
using User.Application.Auth;
using User.API.Dto.Auth;
using Microsoft.Extensions.DependencyInjection;
using User.API;
using User.IoC;
using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Hosting;

namespace User.Test.Login_UH01
{
    public class LoginTest
    {
   
       /* public LoginTest()
        {
            var services = new ServiceCollection();
            StartupTest.AddServiceTest(services);
        }
       */
        [Fact]
        public void Login_Ok_Test()
        {

            //Arrange
           
            LoginDto loginDto = new LoginDto()
            {
                Email = "brianpl",
                Password = "12345"
            };

            LoginMO loginMO = new LoginMO()
            {
                Email = "brianpl",
                Password = "12345"
            };

            LoginResultMO result = new LoginResultMO()
            {
                ResultLogin = 1,
                Token = "seardfgvhsdbfvhwsdbefcvhyg8276t732wtgdqywgedyuqwgvas8yd",
                UserId = 10
            };

            var mockAuthManager = new Mock<IAuthManager>();
            mockAuthManager.Setup(x => x.cero(1)).Returns(1);
            var controller = new AuthController(mockAuthManager.Object);
           
            //Act
            var actionResult = controller.Login(loginDto);

            //Assert
            var ok = actionResult as BadRequestObjectResult;
            var response = ok.Value as LoginResultDto;
            

         // Assert.Equal("seardfgvhsdbfvhwsdbefcvhyg8276t732wtgdqywgedyuqwgvas8yd", response.Token);
           Assert.Equal(10, response.UserId);
       //     Assert.IsType<OkObjectResult>(ok);
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

            LoginMO loginMO = new LoginMO()
            {
                Email = loginDto.Email,
                Password = loginDto.Password
            };

            LoginResultMO result = new LoginResultMO()
            {
                ResultLogin = 0,
             
            };

            var mockAuthManager = new Mock<IAuthManager>();
            mockAuthManager.Setup(auth => auth.SignInWithEmail(loginMO)).Returns(result);
            var controller = new AuthController(mockAuthManager.Object);

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
                Password = "123456"
            };

            LoginMO loginMO = new LoginMO()
            {
                Email = loginDto.Email,
                Password = loginDto.Password
            };

            LoginResultMO result = new LoginResultMO()
            {
                ResultLogin = -1,

            };

            var mockAuthManager = new Mock<IAuthManager>();
            mockAuthManager.Setup(auth => auth.SignInWithEmail(loginMO)).Returns(result);
            var controller = new AuthController(mockAuthManager.Object);

            //Act
            var actionResult = controller.Login(loginDto);

            //Assert

            Assert.IsType<BadRequestResult>(actionResult);

        }

       

    }
}
