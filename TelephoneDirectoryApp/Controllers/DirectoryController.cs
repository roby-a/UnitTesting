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
        public IEnumerable<TelephoneUser> Get()
        {
            return _directoryService.GetAllUsers();
        }

        // GET: api/Directory/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Directory
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Directory/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
