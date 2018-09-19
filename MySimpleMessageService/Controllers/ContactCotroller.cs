using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MySimpleMessageService.Data;
using MySimpleMessageService.Models;

namespace MySimpleMessageService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactCotroller : ControllerBase
    {
        private readonly DataContext context;

        protected ContactCotroller(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var value = context.Contacts.FirstOrDefault(it => it.Id == id);

            return Ok(value);
        }

        [HttpPut("add/{id}")]
        public IActionResult AddUser(int id, Contact item)
        {
            var contact = context.Contacts.Find(id);
            if (contact == null) return NotFound();

            contact.User = item.User;
            contact.FullName = item.FullName;

            context.Contacts.Add(contact);
            context.SaveChanges();
            return NoContent();
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateUser(int id, Contact item)
        {
            var contact = context.Contacts.Find(id);
            if (contact == null) return NotFound();

            contact.User = item.User;
            contact.FullName = item.FullName;

            context.Contacts.Update(contact);
            context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = context.Contacts.Find(id);
            if (todo == null) return NotFound();

            context.Contacts.Remove(todo);
            context.SaveChanges();
            return NoContent();
        }
    }
}

