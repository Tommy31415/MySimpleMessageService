using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using MySimpleMessageService.Controllers;
using MySimpleMessageService.Data;
using MySimpleMessageService.Models;
using Xunit;

namespace MySimpleMessageServiceTest
{
    public class MessageHandlerTest
    {
        private MessageHandler messageHandler;

        public MessageHandlerTest()
        {
            IList<Message> messages = new List<Message>
            {
                new Message
                {
                    Id = 1, MessageDateTime = DateTime.MinValue, Text = "Hello",
                    User = new Contact {FullName = "Jan K", Id = 123, User = "JK"}
                }
            };

            var messageMock = DbSetHelper.CreateDbSetMock(messages);

            var dataContextMock = new Mock<DataContext>();
            dataContextMock.Setup(x => x.Messages).Returns(messageMock.Object);

            messageHandler = new MessageHandler(dataContextMock.Object);
        }

        [Theory]
        [InlineData("JK")]
        public void ShouldReturnMessagesForGivenUser(string user)
        {
            var messages = messageHandler.GetByUser(user);
            Assert.True(messages.Count()>0);
        }

        [Theory]
        [InlineData(1)]
        public void ShouldDelete(int id)
        {
            Assert.True(messageHandler.Delete(1));
        }
    }
}