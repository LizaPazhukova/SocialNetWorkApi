using Moq;
using SocialNetwork.Dal;
using SocialNetwork.Dal.Models;
using SocialNetwork.Logic.Services;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
namespace SocialNetwork.Tests
{
    public class MessageServiceTests
    {
        [Fact]
        public void GetUserMessages_ListWithTwoMessages_ReturnOneMessage()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(repo => repo.Messages.GetAll(x =>x.FromUser)).Returns(GetTestMessages());
            var messageService = new MessageService(mock.Object);

            // Act
            int id = 1;
            var result = messageService.GetUserMessages(id);

            // Assert
            
            Assert.Equal(1, result.FirstOrDefault().Id);
        }
        private IQueryable<Message> GetTestMessages()
        {
            var messages = new List<Message>
            {
                new Message { Id=1, Body="Tom", ToUserId=1, FromUserId = 2 },
                new Message { Id=2, Body="Liza", ToUserId=3, FromUserId = 1},
            };
            return messages.AsQueryable();

        }
        [Fact]
        public void SendMessage_CreateMessage_SaveToTheDB()
        {
            var mockSet = new Mock<IRepository<Message>>();
            var mockContext = new Mock<IUnitOfWork>();
            mockContext.Setup(m => m.Messages).Returns(mockSet.Object);
            var service = new MessageService(mockContext.Object);
            
            service.SendMessage(1, 2, "Message");

            mockSet.Verify(m => m.Create(It.Is<Message>(m=>m.ToUserId==1&&m.FromUserId==2&&m.Body=="Message")), Times.Once());
            mockContext.Verify(m => m.Save(), Times.Once());
        }
        [Fact]
        public void GetUserMessagesWithOneUser_ListWithTwoMessages_ReturnOneMessage()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(repo => repo.Messages.GetAll(x => x.FromUser)).Returns(GetTestMessages());
            var messageService = new MessageService(mock.Object);

            // Act
            var result = messageService.GetUserMessagesWithOneUser(1, 2);

            // Assert

            Assert.Equal(1, result.FirstOrDefault().Id);
        }
    }
}
