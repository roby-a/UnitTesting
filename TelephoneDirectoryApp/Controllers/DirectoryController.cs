using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TelephoneDirectoryApp.Models;
using TelephoneDirectoryApp.Services;

namespace TelephoneDirectoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        protected internal IDirectoryService _directoryService;

        public DirectoryController(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TelephoneUser>> Get()
        {
            var result = _directoryService.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<TelephoneUser> GetUser(int id)
        {
            var result = _directoryService.GetUser(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost]
        public ActionResult<ApiResponse> AddUser(TelephoneUser user)
        {
            var result = _directoryService.AddDetails(user);
            if (result == -1)
                return BadRequest(new ApiResponse() { Status = 0, Message = "Unexpected error occured", Data = 0 });
            return Ok(new ApiResponse() { Status = 1, Message = "Success", Data = result });
        }

        [HttpPut]
        public ActionResult<int> UpdateUser(TelephoneUser user)
        {
            var result = _directoryService.UpdateUser(user);
            if (result == 1)
                return NotFound();
            else if (result == 2)
                return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeleteUser(int id)
        {
            var result = _directoryService.DeleteUser(id);
            if (result == 1)
                return NotFound();
            else if (result == 2)
                return BadRequest();
            return Ok(result);
        }
    }
}
