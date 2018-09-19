using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MySimpleMessageService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactCotroller : ControllerBase
    {
        protected ContactCotroller() { }

        [HttpGet("{user}")]
        public ActionResult<string> GetUser(string user)
        {
            return "value";
        }
        
        [HttpPut("add/{user}")]
        public void AddUser(string user, [FromBody] string value) { }

        [HttpPut("update/{user}")]
        public void UpdateUser(string user, [FromBody] string value) { }

        [HttpDelete("{user}")]
        public void Delete(string user)
        {
            //delete message
        }
    }
}