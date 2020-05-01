using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Dal.Models;
using SocialNetwork.Logic.Interfaces;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("send")]
        public IActionResult Send(Message message)
        {
            var fromUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
          
            _messageService.SendMessage(message.ToUserId, fromUserId, message.Body);
            return Ok();
            
        }

        [HttpGet("messages")]
        public IEnumerable<Message> Messages()
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<Message> messages = _messageService.GetUserMessages(currentUserId);
            return messages;
        }
        [HttpGet("messagesWithOneUser")]
        public IEnumerable<Message> MessagesWithOneUser(int otherUserId, int currentUserId)
        {
            IEnumerable<Message> messages = _messageService.GetUserMessagesWithOneUser(otherUserId, currentUserId);
            return messages;
        }
    }
}