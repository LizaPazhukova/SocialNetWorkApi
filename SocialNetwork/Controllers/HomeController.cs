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

        [HttpGet("posts/{userId}")]
        public IEnumerable<Post> Get(int userId)
        {
            IEnumerable<Post> posts = _postService.GetPosts(userId).ToList();

            return posts;
        }
        [HttpGet("currentUser")]
        public UserDTO GetCurrentUser()
        {
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return _userService.GetUser(userId);
        }
        [HttpGet("user/{id}")]
        public UserDTO GetUser(int id)
        {
            return _userService.GetUser(id);
        }

        [HttpPost("users")]
        public IEnumerable<UserDTO> Users(SearchUser searchUser)
        {
            IEnumerable<UserDTO> users = _userService.GetUsers(searchUser);
            return users;
        }
        [HttpPost]
        public IEnumerable<UserDTO> Search(string name)
        {
            IEnumerable<UserDTO> users = _userService.SearchedUsers(name);

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
        public IActionResult CreateComment(Comment comment)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _postService.CreateComment(comment.PostId, userId, comment.Text);
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