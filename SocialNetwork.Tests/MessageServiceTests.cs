using Moq;
using SocialNetwork.Dal;
using SocialNetwork.Dal.Models;
using SocialNetwork.Logic.Services;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using AutoMapper;
using SocialNetwork.Logic.Interfaces;
using SocialNetwork.Logic.MappingProfiles;
using FluentAssertions;
using SocialNetwork.Logic.Exceptions;

namespace SocialNetwork.Tests
{
    public class MessageServiceTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IMessageService _messageService;
        private IMapper _mapper;
        public MessageServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            _mapper = new Mapper(config);
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(m => m.Messages.GetAll(x => x.FromUser)).Returns(GetTestMessages());
            _messageService = new MessageService(_mockUnitOfWork.Object, _mapper);
        }
        [Fact]
        public void GetUserMessages_ListWithTwoMessages_ReturnOneMessage()
        {
            // Arrange
            int userId = 2;

            // Act
            var result = _messageService.GetUserMessages(userId);

            // Assert
            result.Count().Should().Be(1);
            result.FirstOrDefault().Id.Should().Be(1);
        }

        [Fact]
        public void SendMessage_CreateMessage_SaveToTheDB()
        {
            int fromUser = 1;
            int toUser = 2;
            string text = "Message";

            _messageService.SendMessage(toUser, fromUser, text);

            _mockUnitOfWork.Verify(m => m.Messages.Create(It.Is<Message>(m => m.ToUserId == toUser && m.FromUserId == fromUser && m.Body == text)), Times.Once());
            _mockUnitOfWork.Verify(m => m.Save(), Times.Once());
        }

        [Fact]
        public void DeleteMessage_WithExistingId_RemoveFromDb()
        {
            int userId = 1;
            _mockUnitOfWork.Setup(m => m.Messages.GetById(userId)).Returns(new Message { Id = 1, Body = "Tom", ToUserId = 1, FromUserId = 2 });

            _messageService.Delete(userId);

            _mockUnitOfWork.Verify(m => m.Messages.Delete(It.Is<Message>(m => m.Id == userId)), Times.Once());
            _mockUnitOfWork.Verify(m => m.Save(), Times.Once());
        }
        [Fact]
        public void DeleteMessage_WithNotExistingId_ThrowException()
        {
            int userId = 100;
            _mockUnitOfWork.Setup(m => m.Messages.GetById(userId)).Returns((Message)null);

            Action act = () => _messageService.Delete(userId);

            act.Should().Throw<NotFoundException>();
        }
        private IQueryable<Message> GetTestMessages()
        {
            var messages = new List<Message>
                {
                    new Message { Id=1, Body="Tom", ToUserId = 1, FromUserId = 2 },
                    new Message { Id=2, Body="Liza", ToUserId = 3, FromUserId = 1},
                };
            return messages.AsQueryable();
        }
    }
}
