using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MySimpleMessageService.Data;
using MySimpleMessageService.Models;
using Remotion.Linq.Clauses;

namespace MySimpleMessageService.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageHandler messageHandler;

        public MessageController(DataContext context)
        {
            messageHandler = new MessageHandler(context);
        }

        [HttpGet("{user}")]
        public IActionResult GetByUser(string user)
        {
            return Ok(messageHandler.GetByUser(user));
        }

        [HttpGet("{user}/{date}")]
        public IActionResult GetByDate(string user, string date)
        {
          return Ok(messageHandler.GetByDate(user, date));
        }

        [HttpGet("{user}/{sortype}")]
        public IActionResult SortByDate(string user, ESortType sortype)
        {
            return Ok(messageHandler.SortByDate(user, sortype));
        }

        [HttpGet("{user}/{results}/{page}")]
        public IActionResult GetPage(int results, int page, string user)
        {
            return Ok(messageHandler.GetPage(results, page, user));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (messageHandler.Delete(id)) return NoContent();
            return NotFound();
        }
    }
}