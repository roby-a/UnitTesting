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
        // GET: api/Directory
        [HttpGet]
        public ActionResult<IEnumerable<TelephoneUser>> Get()
        {
            var result = _directoryService.GetAllUsers();
            return Ok(result);
        }

    }
}
