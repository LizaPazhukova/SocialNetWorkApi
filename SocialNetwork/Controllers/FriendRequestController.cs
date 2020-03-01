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
    public class FriendRequestController : ControllerBase
    {
        private readonly IFriendRequestService _friendRequestService;

        public FriendRequestController(IFriendRequestService friendRequestService)
        {
            _friendRequestService = friendRequestService;
        }

        //[HttpGet]
        //public IActionResult GetRequest(int id)
        //{
        //    return View();
        //}
        [HttpGet("sendRequest/{id}")]
        public IActionResult SendRequest(int id)
        {
            var fromUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _friendRequestService.SendRequest(id, fromUserId);
            return Ok();
        }
        public IEnumerable<Request> Requests()
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<Request> requests = _friendRequestService.GetCurrentUserRequest(currentUserId);

            return requests;
        }
        public IActionResult AcceptRequest(int id)
        {
            _friendRequestService.AcceptRequest(id);
            return RedirectToAction("Requests", "FriendRequest");
        }
        public IActionResult RegectRequest(int id)
        {
            _friendRequestService.RejectRequest(id);
            return RedirectToAction("Requests", "FriendRequest");
        }
        public IEnumerable<AppUser> Friends()
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            IEnumerable<AppUser> friends = _friendRequestService.GetUserFriends(currentUserId);
            return friends;
        }
    }
}