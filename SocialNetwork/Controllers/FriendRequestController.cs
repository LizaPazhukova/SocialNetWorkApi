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

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendRequestController : ControllerBase
    {
        private readonly IFriendRequestService _friendRequestService;

        public FriendRequestController(IFriendRequestService friendRequestService)
        {
            _friendRequestService = friendRequestService;
        }

        [HttpGet("sendRequest/{id}")]
        public IActionResult SendRequest(int id)
        {
            var fromUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _friendRequestService.SendRequest(id, fromUserId);
            return Ok();
        }
        [HttpGet("requests")]
        public IEnumerable<RequestDTO> Requests()
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<RequestDTO> requests = _friendRequestService.GetCurrentUserRequest(currentUserId);

            return requests;
        }
        [HttpGet("acceptRequest/{id}")]
        public IActionResult AcceptRequest(int id)
        {
            _friendRequestService.AcceptRequest(id);
            return Ok();
           
        }
        [HttpGet("rejectRequest/{id}")]
        public IActionResult RejectRequest(int id)
        {
            _friendRequestService.RejectRequest(id);
            return Ok();
        }
        [HttpGet("friends")]
        public IEnumerable<UserDTO> Friends()
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            IEnumerable<UserDTO> friends = _friendRequestService.GetUserFriends(currentUserId);
            return friends;
        }
    }
}