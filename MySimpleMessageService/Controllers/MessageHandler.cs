using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySimpleMessageService.Data;
using MySimpleMessageService.Models;

namespace MySimpleMessageService.Controllers
{
    public class MessageHandler
    {
        private readonly DataContext context;

        public MessageHandler(DataContext context)
        {
            this.context = context;
        }

        public IQueryable<Message> GetByUser(string user)
        {
            var messages = context.Messages.Where(c => c.User.User == user);

            return messages;
        }

        public IQueryable<Message> GetByDate(string user, string date)
        {
            DateTime dt =
                DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var messages = from mes in context.Messages where mes.MessageDateTime >= dt select mes;

            return messages;
        }

        public IOrderedQueryable<Message> SortByDate(string user, ESortType sortype)
        {
            var messages = sortype == ESortType.Desc ? context.Messages.OrderByDescending(mes => mes.MessageDateTime) : context.Messages.OrderBy(mes => mes.MessageDateTime);

            return messages;
        }


        public IQueryable<Message> GetPage(int results, int page, string user)
        {
            var messages = context.Messages.Where(c => c.User.User == user)
                .Skip(results * page)
                .Take(results);

            return messages;
        }


        public bool Delete(int id)
        {
            var message = context.Messages.Find(id);
            if (message == null) return false;

            context.Messages.Remove(message);
            context.SaveChanges();
            return true;
        }
    }

    public enum ESortType
    {
        Asc,
        Desc
    }
}
