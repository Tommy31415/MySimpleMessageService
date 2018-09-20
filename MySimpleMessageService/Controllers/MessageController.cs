using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MySimpleMessageService.Data;

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
        private readonly DataContext context;

        public MessageController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("{user}")]
        public IActionResult GetByUser(string user)
        {
            var messages = context.Messages.Where(c => c.User.User == user); 

            return Ok(messages);
        }

        // GET api/values/user
        [HttpGet("page/{page}")]
        public ActionResult<string> GetPage(int page)
        {
            return "value";
        }

        // POST api/values
        [HttpGet("page/{results}/{page}/{user}")]
        public IActionResult GetByDate(int results, int page, string user)
        {
            var messages = context.Messages.Where(c => c.User.User == user)
                .Skip(results * page)
                .Take(results);

            return Ok(messages);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var message = context.Messages.Find(id);
            if (message == null) return NotFound();

            context.Messages.Remove(message);
            context.SaveChanges();
            return NoContent();
        }
    }
}