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

        //[HttpGet]
        //public IActionResult Send(int id)
        //{
        //    return View();
        //}

        [HttpPost("send")]
        public IActionResult Send(int id, string messageText)
        {
            var fromUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _messageService.SendMessage(id, fromUserId, messageText);
            return RedirectToAction("Index", "Home");
            //return IActionResult<Message>(message)
        }

        [HttpGet("messages")]
        public IEnumerable<Message> Messages()
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<Message> messages = _messageService.GetUserMessages(currentUserId);
            return messages;
        }
        public IEnumerable<Message> MessagesWithOneUser()
        {
            IEnumerable<Message> messages = _messageService.GetUserMessagesWithOneUser();
            return messages;
        }
    }
}