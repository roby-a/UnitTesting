using Microsoft.AspNetCore.Mvc;
using System;
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
        
        [Fact]
        public void GetAllUsersTest()
        {
            //arrange
            //act
            var result = _controller.Get();
            //assert
            Assert.IsType<OkObjectResult>(result.Result);

            var objResult = result.Result as OkObjectResult;
            var list = objResult.Value as List<TelephoneUser>;

            Assert.Equal(6,list.Count);
        }
    }
}
