using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using MySimpleMessageService.Controllers;
using MySimpleMessageService.Data;
using MySimpleMessageService.Models;
using Xunit;

namespace MySimpleMessageServiceTest
{
    public class ContactHandlerTest
    {
        private ContactsHandler contactsHandler;

        public ContactHandlerTest()
        {
            IList<Contact> contacts = new List<Contact>
            {
                new Contact(){FullName = "Jan K", Id=123,User ="JK"}
            };

            var contactsMock = DbSetHelper.CreateDbSetMock(contacts);

            var dataContextMock = new Mock<DataContext>();
            dataContextMock.Setup(x => x.Contacts).Returns(contactsMock.Object);

            contactsHandler = new ContactsHandler(dataContextMock.Object);
        }

        [Theory]
        [InlineData(123)]
        public void ShouldReturnValidUser(int id)
        {
             var contact = contactsHandler.GetUser(id);
            Assert.Equal("JK",contact.User);
        }


        [Theory]
        [InlineData("tp","Tommy P")]
        public void ShouldAddUser(string userName, string fullName)
        {
            var inputContact = new Contact() {FullName = fullName, Id = 12, User = userName};
            var res = contactsHandler.AddUser(inputContact);
            Assert.True(res);
        }

        [Theory]
        [InlineData("tp", "Tommy P")]
        public void ShouldUpdateUser(string userName, string fullName)
        {
            var inputContact = new Contact() { FullName = fullName, Id = 123, User = userName };
            var res = contactsHandler.UpdateUser(inputContact);
            Assert.True(res);
        }

        [Theory]
        [InlineData(123)]
        public void ShouldDelete(int id)
        {
            var res = contactsHandler.Delete(id);
            Assert.True(res);
        }
    }
}
