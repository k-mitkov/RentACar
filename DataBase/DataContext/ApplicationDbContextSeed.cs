using DataBase.Models;
using Microsoft.AspNetCore.Identity;

namespace DataBase.DataContext
{
    public class ApplicationDbContextSeed
    {
        /// <summary>
        /// Създава default админ, ако няма вече създаден такъв
        /// </summary>
        /// <param name="userManager"></param>
        public static void Seed(UserManager<User> userManager)
        {
            if (userManager.FindByEmailAsync("no-reply.techno_world@abv.bg").Result == null)
            {
                var user = new User
                {
                    UserName = "Admin",
                    Email = "no-reply.techno_world@abv.bg"
                };

                IdentityResult result = userManager.CreateAsync(user, "Admin123!@#").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
    }
}
