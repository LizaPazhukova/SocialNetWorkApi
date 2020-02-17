using SocialNetwork.Dal.Models;
using SocialNetwork.Dal.Repositories;
using SocialNetwork.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Logic.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public IEnumerable<Message> GetUserMessages(int currentUserId)
        {
            return _messageRepository.GetAll(x => x.AppUser)
                                     .Where(x => x.ToUserId == currentUserId || x.FromUserId == currentUserId)
                                     .GroupBy(m => new
                                     {
                                         MinId = m.FromUserId <= m.ToUserId ? m.FromUserId : m.ToUserId,
                                         MaxId = m.FromUserId > m.ToUserId ? m.FromUserId : m.ToUserId
                                     })
                                     .Select(gm => gm.OrderByDescending(m => m.Date)
                                     .FirstOrDefault()); 
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
            _messageRepository.Create(message);
        }
        public IEnumerable<Message> GetUserMessagesWithOneUser()
        {
            return _messageRepository.GetAll(x => x.AppUser)
                                     .GroupBy(m => new
                                     {

                                     })
                                     .Select(gm => gm.OrderByDescending(m => m.Date)
                                     .FirstOrDefault());
        }
    }
}
