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
            IEnumerable<Post> posts = _postService.GetPosts();

            return posts;
        }

        [HttpGet("users")]
        public IEnumerable<AppUser> Users()
        {
            IEnumerable<AppUser> users = _userService.GetUsers();
            return users;
        }
        [HttpPost]
        public IEnumerable<AppUser> Search(string name)
        {
            IEnumerable<AppUser> users = _userService.SearchedUsers(name);

            return users;
        }

        [HttpPost("post")]
        public IActionResult Create([FromBody]PostInput input)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _postService.Create(userId, input.Text);
            return Ok();
        }
        [HttpPost("comment")]
        public IActionResult CreateComment(int id, string text)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _postService.CreateComment(id, userId, text);
            return Ok();
        }
        public IActionResult LikePost(int id)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _postService.LikePost(userId, id);
            return RedirectToAction("Index");
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}