using AutoMapper;
using SocialNetwork.Dal;
using SocialNetwork.Dal.Models;
using SocialNetwork.Dal.Repositories;
using SocialNetwork.Logic.DTO;
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
    }
}
