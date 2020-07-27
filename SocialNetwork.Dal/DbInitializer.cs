using Microsoft.AspNetCore.Identity;
using SocialNetwork.Dal.Models;

namespace SocialNetwork.Dal
{
    public class DbInitializer
    {
        public static void SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUser(userManager);
        }

        private static void SeedUser(UserManager<AppUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@gmail.com").Result == null)
            {
                AppUser user = new AppUser();
                user.UserName = "admin@gmail.com";
                user.Email = "admin@gmail.com";
                user.FirstName = "Admin";
                user.LastName = "Admin";

                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<AppRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                AppRole role = new AppRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                AppRole role = new AppRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Moderator").Result)
            {
                AppRole role = new AppRole();
                role.Name = "Moderator";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
