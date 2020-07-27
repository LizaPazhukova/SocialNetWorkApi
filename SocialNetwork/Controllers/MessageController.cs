using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Dal.Models;
using SocialNetwork.Logic.DTO;
using SocialNetwork.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Send(MessageDTO message)
        {
            var fromUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
          
            _messageService.SendMessage(message.ToUserId, fromUserId, message.Body);
            return Ok();
            
        }

        [HttpGet("messages")]
        public IEnumerable<MessageDTO> Messages()
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<MessageDTO> messages = _messageService.GetUserMessages(currentUserId);
            return messages;
        }
        [HttpGet("messagesWithOneUser/{fromUserId}/{toUserId}")]
        public IEnumerable<MessageDTO> MessagesWithOneUser(int fromUserId, int toUserId)
        {
            
            IEnumerable<MessageDTO> messages = _messageService.GetUserMessagesWithOneUser(fromUserId, toUserId);
            return messages;
        }

        [HttpGet("allMessages")]
        public IEnumerable<MessageDTO> GetAllMessages()
        {
            IEnumerable<MessageDTO> messages = _messageService.GetAllMessages();
            return messages;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            _messageService.Delete(id);

            return NoContent();
        }
        [HttpPut("update")]
        public IActionResult UpdateMessage(MessageDTO messageDto)
        {
            _messageService.UpdateMessage(messageDto);

            return NoContent();
        }

        [HttpGet("count")]
        public int CountUnreadedMessages()
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return _messageService.CountUnreadedMessages(currentUserId);
        }

        [HttpGet("setUnreadedMessages")]
        public void SetUnreadedMessages()
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            _messageService.SetUnreadedMessages(currentUserId);
        }
    }
}