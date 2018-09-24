using System.Linq;
using MySimpleMessageService.Data;
using MySimpleMessageService.Models;

namespace MySimpleMessageService.Controllers {
    public class ContactsHandler {
        private readonly DataContext context;
        public ContactsHandler(DataContext context)
        {
            this.context = context;
        }

        public Contact GetUser(int id)
        {
            var value = context.Contacts.FirstOrDefault(it => it.Id == id);

            return value;
        }

        public bool AddUser(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
            return true;
        }

        public bool UpdateUser(Contact contact)
        {
            var existingContact = context.Contacts.Find(contact.Id);
            if (existingContact == null) return false;

            existingContact.User = contact.User;
            existingContact.FullName = contact.FullName;

            context.Contacts.Update(existingContact);
            context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var contact = context.Contacts.Find(id);
            if (contact == null) return false;

            context.Contacts.Remove(contact);
            context.SaveChanges();
            return true;
        }
    }
}