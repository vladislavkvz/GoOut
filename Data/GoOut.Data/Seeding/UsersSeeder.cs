namespace GoOut.Data.Seeding
{
    using System;
    using Models;
    using System.Linq;
    using GoOut.Common;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(DbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            User admin = new User()
            {
                UserName = GlobalConstants.AdminUsername,
                Email = GlobalConstants.AdminEmail,
                FirstName = GlobalConstants.AdminFirstName,
                LastName = GlobalConstants.AdminLastName
            };

            await SeedUserAsync(userManager, admin, GlobalConstants.AdminPassword, GlobalConstants.AdminRoleName);
        }

        private static async Task SeedUserAsync(UserManager<User> userManager, User newUser, string password, string role)
        {
            var user = await userManager.FindByNameAsync(newUser.UserName);
            if (user == null)
            {
                IdentityResult result = userManager.CreateAsync(newUser, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(newUser, role).Wait();
                }
                else
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}