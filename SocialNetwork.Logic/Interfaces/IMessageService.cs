using SocialNetwork.Dal.Models;
using SocialNetwork.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.Logic.Interfaces
{
    public interface IMessageService
    {
        void SendMessage(int toUserId, int fromUserId, string messageText);
        IEnumerable<MessageDTO> GetUserMessages(int currentUserId);
        IEnumerable<MessageDTO> GetUserMessagesWithOneUser(int otherUserId, int curentUserId);
    }
}
