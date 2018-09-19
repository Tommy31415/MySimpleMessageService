using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySimpleMessageService.Models
{
    public class Message
    {
        public int Id { get; set; }

        public Contact User { get; set; }

        public string Text { get; set; }
    }
}
