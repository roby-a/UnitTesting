using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<int> AddUser(TelephoneUser user)
        {
            var result = _directoryService.AddDetails(user);
            if (result == -1)
                return BadRequest();
            return Ok(result);
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

        [HttpDelete]
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
