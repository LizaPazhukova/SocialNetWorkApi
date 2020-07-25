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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
       
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("currentUser")]
        public async Task<UserDTO> GetCurrentUser()
        {
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return await _userService.GetUser(userId);
        }
        [HttpGet("{id}")]
        public async Task<UserDTO> GetUser(int id)
        {
            return await _userService.GetUser(id);
        }

        [HttpPost]
        public IEnumerable<UserDTO> Users(SearchUser searchUser)
        {
            IEnumerable<UserDTO> users = _userService.GetUsers(searchUser);
            return users;
        }
    }
}