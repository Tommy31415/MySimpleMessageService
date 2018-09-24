using Microsoft.AspNetCore.Mvc;
using MySimpleMessageService.Data;
using MySimpleMessageService.Models;

namespace MySimpleMessageService.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ContactCotroller : ControllerBase
    {
        private readonly ContactsHandler contactsHandler;

        protected ContactCotroller(DataContext context)
        {
            contactsHandler = new ContactsHandler(context);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            return Ok(contactsHandler.GetUser(id));
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] Contact item)
        {
            if (contactsHandler.AddUser(item))
                return NoContent();

            return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateUser([FromBody] Contact item)
        {
            if (contactsHandler.UpdateUser(item))
                return NoContent();

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (contactsHandler.Delete(id)) return NoContent();
            return NotFound();
        }
    }
}