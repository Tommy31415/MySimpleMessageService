using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MySimpleMessageService.Data;
using MySimpleMessageService.Models;
using Remotion.Linq.Clauses;

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

        [HttpGet("/{user}?from={date}")]
        public IActionResult GetByDate(string user, string date)
        {

            DateTime dt =
                DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var messages = from mes in context.Messages where mes.MessageDateTime >= dt select mes;

            return Ok(messages);
        }

        [HttpGet("/{user}?sortbydate={sortype}")]
        public IActionResult SortByDate(string user, string sortype)
        {
            
            var messages = sortype == "desc" ? context.Messages.OrderByDescending(mes => mes.MessageDateTime) : context.Messages.OrderBy(mes => mes.MessageDateTime);

            return Ok(messages);
        }


        [HttpGet("/{user}?r={results}&p={page}")]
        public IActionResult GetPage(int results, int page, string user)
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