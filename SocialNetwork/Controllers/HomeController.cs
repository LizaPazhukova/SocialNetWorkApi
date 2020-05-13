using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Logic.Services;
using SocialNetwork.Logic.Interfaces;
using SocialNetwork.Dal.Models;
using System.Security.Claims;
using SocialNetwork.Inputs;
using SocialNetwork.Logic.DTO;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        public HomeController(IUserService userService, IPostService postService)
        {
            _userService = userService;
            _postService = postService;
        }

        [HttpGet("posts")]
        public IEnumerable<Post> Get()
        {
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<Post> posts = _postService.GetPosts(userId);

            return posts;
        }
        [HttpGet("currentUser")]
        public AppUser GetCurrentUser()
        {
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return _userService.GetUser(userId);
        }

        [HttpPost("users")]
        public IEnumerable<AppUser> Users(SearchUser searchUser)
        {
            IEnumerable<AppUser> users = _userService.GetUsers(searchUser);
            return users;
        }
        [HttpPost]
        public IEnumerable<AppUser> Search(string name)
        {
            IEnumerable<AppUser> users = _userService.SearchedUsers(name);

            return users;
        }

        [HttpPost("post")]
        public IActionResult Create(Post post)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _postService.Create(userId, post.Text);
            return CreatedAtAction("Get", new { id = post.Id }, post);
        }
        [HttpPost("comment")]
        public IActionResult CreateComment(int id, string text)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _postService.CreateComment(id, userId, text);
            return Ok();
        }
        [HttpPost("like")]
        public IActionResult LikePost(Like like)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _postService.LikePost(userId, like.PostId);
            return Ok();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}