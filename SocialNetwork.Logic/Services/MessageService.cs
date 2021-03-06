﻿using AutoMapper;
using SocialNetwork.Dal;
using SocialNetwork.Dal.Models;
using SocialNetwork.Logic.DTO;
using SocialNetwork.Logic.Exceptions;
using SocialNetwork.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Logic.Services
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<MessageDTO> GetUserMessages(int currentUserId)
        {
            var messages = _unitOfWork.Messages.GetAll(x => x.FromUser).AsEnumerable()
                                     .Where(x => x.ToUserId == currentUserId || x.FromUserId == currentUserId)
                                     .GroupBy(m => new
                                     {
                                         MinId = m.FromUserId <= m.ToUserId ? m.FromUserId : m.ToUserId,
                                         MaxId = m.FromUserId > m.ToUserId ? m.FromUserId : m.ToUserId
                                     })
                                     .Select(gm => gm.OrderByDescending(m => m.Date).ToList()
                                     .FirstOrDefault());
            return _mapper.Map<IEnumerable<MessageDTO>>(messages);
        }

        public void SendMessage(int toUserId, int fromUserId, string messageText)
        {
            Message message = new Message()
            {
                Body = messageText,
                FromUserId = fromUserId,
                Date = DateTime.Now,
                ToUserId = toUserId
            };
            _unitOfWork.Messages.Create(message);
            _unitOfWork.Save();
        }
        public IEnumerable<MessageDTO> GetUserMessagesWithOneUser(int fromUserId, int toUserId)
        {
            var messages = _unitOfWork.Messages.GetAll(x => x.FromUser)
                .Where(x => x.ToUserId == toUserId && x.FromUserId == fromUserId || x.ToUserId == fromUserId && x.FromUserId == toUserId).ToList();
            return _mapper.Map<IEnumerable<MessageDTO>>(messages);
        }

        public IEnumerable<MessageDTO> GetAllMessages()
        {
            var messages = _unitOfWork.Messages.GetAll(x => x.FromUser);

            return _mapper.Map<IEnumerable<MessageDTO>>(messages);
        }

        public void UpdateMessage(MessageDTO messageDto)
        {
            if(messageDto == null)
            {
                throw new ArgumentNullException("Message shouldn't be null");
            }

            var message = _unitOfWork.Messages.GetById(messageDto.Id);

            if (message == null)
            {
                throw new NotFoundException($"Message with {messageDto.Id} doesn't exist");
            }

            message.Body = messageDto.Body;

            _unitOfWork.Messages.Update(message);

            _unitOfWork.Save();
        }

        public void Delete(int messageId)
        {
            var message = _unitOfWork.Messages.GetById(messageId);

            if(message == null)
            {
                throw new NotFoundException($"Message with {messageId} doesn't exist");
            }

            _unitOfWork.Messages.Delete(message);

            _unitOfWork.Save();
        }

        public int CountUnreadedMessages(int currentUserId)
        {
            return _unitOfWork.Messages.GetAll().Where(x =>x.ToUserId == currentUserId && x.isReaded == false).Count();
        }

        public void SetUnreadedMessages(int currentUserId)
        {
            var unreadedMessages = _unitOfWork.Messages.GetAll().Where(x => x.ToUserId == currentUserId && x.isReaded == false);

            foreach(var message in unreadedMessages)
            {
                message.isReaded = true;
                _unitOfWork.Messages.Update(message);
            }

            _unitOfWork.Save();
        }
    }
}
