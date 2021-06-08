using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TelephoneDirectoryApp.Controllers;
using TelephoneDirectoryApp.Models;
using TelephoneDirectoryApp.Services;
using Xunit;

namespace TelephoneDirectoryApp.Test
{
    public class TelephoneDirectoryTest
    {
        DirectoryController _controller;
        IDirectoryService _service;

        public TelephoneDirectoryTest()
        {
            _service = new DirectoryService();
            _controller = new DirectoryController(_service);
        }

        [Fact]//(Skip = "Add test in progress")]
        public void GetAllUsersTest()
        {
            //arrange
            //act
            var result = _controller.Get();
            //assert
            Assert.IsType<OkObjectResult>(result.Result);

            var objectResult = result.Result as OkObjectResult;
            var userList = objectResult.Value as IEnumerable<TelephoneUser>;

            Assert.Equal(27, userList.Count());
        }

        [Theory]
        [InlineData(2, 789)]
        public void GetUserTest(int validId, int invalidId)
        {
            var validUser = _controller.GetUser(validId);
            var invalidUser = _controller.GetUser(invalidId);
            var objectResult = validUser.Result as OkObjectResult;
            var user = objectResult.Value as TelephoneUser;

            Assert.IsType<OkObjectResult>(validUser.Result);
            Assert.IsType<BadRequestResult>(invalidUser.Result);
            Assert.Equal(2, user.Id);
        }

        [Fact]
        public void AddUserTest()
        {
            //arrange
            var validDetail = new TelephoneUser()
            {
                FirstName = "Test",
                LastName = "TestLast",
                Number = 2346892,
                Location = "Canada"
            };
            var invalidDetail = new TelephoneUser()
            {
                LastName = "TestLast",
                Location = "Canada"
            };

            //act
            var validResult = _controller.AddUser(validDetail);
            var invalidResult = _controller.AddUser(invalidDetail);

            var responseObject = validResult.Result as OkObjectResult;
            var response = responseObject.Value as ApiResponse;

            var newAdditionCheck = _controller.GetUser(response.Data);

            var newAdditionCheckObject = newAdditionCheck.Result as OkObjectResult;
            var newAdditionCheckObjectValue = newAdditionCheckObject.Value as TelephoneUser;

            //assert
            Assert.IsType<OkObjectResult>(validResult.Result);
            Assert.IsType<BadRequestObjectResult>(invalidResult.Result);
            Assert.Equal(1, response.Status);
            Assert.Equal(validDetail.FirstName, newAdditionCheckObjectValue.FirstName);

        }

        [Theory]
        [InlineData(35,37)]
        public void DeleteUserTest(int validId,int invalidId)
        {
            var validResult = _controller.DeleteUser(validId);
            var invalidResult = _controller.DeleteUser(invalidId);


            Assert.IsType<OkObjectResult>(validResult.Result);
            Assert.IsType<NotFoundObjectResult>(invalidResult.Result);
        }
    }
}
