using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MySimpleMessageService.Controllers
{
    /**
     * Send a message to another contact within the engine.
       ○ Read messages
       ○ Delete a message
       ○ Apply filtering, pagination and sorting
     */

    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        // GET  read Messagess: from who and text and message id
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/user
        [HttpGet("byuser/{user}")]
        public ActionResult<string> GetByUser(string user)
        {
            return "value";
        }

        // GET api/values/user
        [HttpGet("page/{page}")]
        public ActionResult<string> GetPage(int  page)
        {
            return "value";
        }

//        // POST api/values
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }
//
//        // PUT api/values/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
      //  }

        // DELETE api/values/5
        [HttpDelete("{id}")] 
        public void Delete(int id)
        {
            //delete message
        }
    }
}
