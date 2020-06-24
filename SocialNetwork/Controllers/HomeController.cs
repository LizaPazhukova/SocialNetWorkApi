using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Logic.Interfaces;
using System.Security.Claims;
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
        public IEnumerable<PostDTO> Get(int userId)
        {
            IEnumerable<PostDTO> posts = _postService.GetPosts(userId).ToList();

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
        public ActionResult<PostDTO> Create(PostDTO post)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //return Ok(_postService.Create(userId, post.Text)); //
            _postService.Create(userId, post.Text);
            return CreatedAtAction("Get", new { id = post.Id }, post);
        }
        [HttpPost("comment")]
        public IActionResult CreateComment(CommentDTO comment)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _postService.CreateComment(comment.PostId, userId, comment.Text);
            return Ok();
        }
        [HttpPost("like")]
        public IActionResult LikePost(LikeDTO like)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _postService.LikePost(userId, like.PostId);
            return Ok();
        }
        [HttpDelete("post/{id}")]
        public IActionResult DeletePost(int id)
        {
            _postService.Delete(id);
            return NoContent();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}