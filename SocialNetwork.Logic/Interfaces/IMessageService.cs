using SocialNetwork.Logic.DTO;
using System.Collections.Generic;

namespace SocialNetwork.Logic.Interfaces
{
    public interface IMessageService
    {
        void SendMessage(int toUserId, int fromUserId, string messageText);
        IEnumerable<MessageDTO> GetUserMessages(int currentUserId);
        IEnumerable<MessageDTO> GetUserMessagesWithOneUser(int otherUserId, int curentUserId);
        IEnumerable<MessageDTO> GetAllMessages();
        void UpdateMessage(MessageDTO message);
        void Delete(int messageId);
    }
}
