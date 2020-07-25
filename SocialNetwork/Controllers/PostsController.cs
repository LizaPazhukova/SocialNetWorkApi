using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Logic.DTO;
using SocialNetwork.Logic.Interfaces;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("{userId}")]
        public IEnumerable<PostDTO> Get(int userId)
        {
            IEnumerable<PostDTO> posts = _postService.GetPosts(userId).ToList();

            return posts;
        }

        [HttpPost]
        public ActionResult<PostDTO> Create(PostDTO post)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //return Ok(_postService.Create(userId, post.Text)); //
            _postService.Create(userId, post.Text);
            return CreatedAtAction("Get", new { id = post.Id }, post);
        }

        [HttpPost("like")]
        public IActionResult LikePost(LikeDTO like)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _postService.LikePost(userId, like.PostId);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            _postService.Delete(id);
            return NoContent();
        }

        [HttpPost("comment")]
        public IActionResult CreateComment(CommentDTO comment)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _postService.CreateComment(comment.PostId, userId, comment.Text);
            return Ok();
        }
    }
}