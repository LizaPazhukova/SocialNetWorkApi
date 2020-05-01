using SocialNetwork.Dal;
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
        private readonly IUnitOfWork _unitOfWork;
        public MessageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Message> GetUserMessages(int currentUserId)
        {
            return _unitOfWork.Messages.GetAll().Where(x => x.ToUserId == currentUserId || x.FromUserId == currentUserId).ToList();
            //return _unitOfWork.Messages.GetAll(x => x.AppUser)
            //                         .Where(x => x.ToUserId == currentUserId || x.FromUserId == currentUserId)
            //                         .GroupBy(m => new
            //                         {
            //                             MinId = m.FromUserId <= m.ToUserId ? m.FromUserId : m.ToUserId,
            //                             MaxId = m.FromUserId > m.ToUserId ? m.FromUserId : m.ToUserId
            //                         })
            //                         .Select(gm => gm.OrderByDescending(m => m.Date)
            //                         .FirstOrDefault()).ToList(); 
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
        public IEnumerable<Message> GetUserMessagesWithOneUser(int otherUserId, int currentUserId)
        {
            return _unitOfWork.Messages.GetAll(x => x.AppUser)
                                     .Where(x => x.ToUserId == currentUserId && x.FromUserId == otherUserId || x.ToUserId == otherUserId && x.FromUserId == currentUserId)
                                     .GroupBy(m => new
                                     {
                                         MinId = m.FromUserId <= m.ToUserId ? m.FromUserId : m.ToUserId,
                                         MaxId = m.FromUserId > m.ToUserId ? m.FromUserId : m.ToUserId
                                     })
                                     .Select(gm => gm.OrderByDescending(m => m.Date)
                                     .FirstOrDefault());
        }
    }
}
