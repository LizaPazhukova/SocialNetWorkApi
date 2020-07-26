using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Dal.Models;
using SocialNetwork.Logic.DTO;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        RoleManager<AppRole> _roleManager;
        UserManager<AppUser> _userManager;
        public RolesController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IEnumerable<AppRole> GetRoles()
        {
            var roles = _roleManager.Roles.ToList();

            return roles;
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<string>> GetRoles(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            
            var roles = await _userManager.GetRolesAsync(user);

            return roles;
        }

     //   [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> AssignRolesToUser(string id, UpdateUserRolesDTO dto)
        {
            var rolesToAssign = dto.RolesToAssign;

            var appUser = await _userManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            var currentRoles = await _userManager.GetRolesAsync(appUser);

            var rolesNotExists = rolesToAssign.Except(_roleManager.Roles.Select(x => x.Name)).ToArray();

            if (rolesNotExists.Count() > 0)
            {

                ModelState.AddModelError("", string.Format("Roles '{0}' does not exixts in the system", string.Join(",", rolesNotExists)));
                return BadRequest(ModelState);
            }

            IdentityResult removeResult = await _userManager.RemoveFromRolesAsync(appUser, currentRoles.ToArray());

            if (!removeResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to remove user roles");
                return BadRequest(ModelState);
            }

            IdentityResult addResult = await _userManager.AddToRolesAsync(appUser, rolesToAssign);

            if (!addResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to add user roles");
                return BadRequest(ModelState);
            }

            return Ok();
        }
        //public async Task<IActionResult> Edit(string userId)
        //{

        //    // получаем пользователя
        //    AppUser user = await _userManager.FindByIdAsync(userId);
        //    if (user != null)
        //    {
        //        // получем список ролей пользователя
        //        var userRoles = await _userManager.GetRolesAsync(user);
        //        var allRoles = _roleManager.Roles.ToList();
        //        ChangeRoleViewModel model = new ChangeRoleViewModel
        //        {
        //            UserId = user.Id,
        //            UserEmail = user.Email,
        //            UserRoles = userRoles,
        //            AllRoles = allRoles
        //        };
        //        return View(model);
        //    }

        //    return NotFound();
        //}
    }
}