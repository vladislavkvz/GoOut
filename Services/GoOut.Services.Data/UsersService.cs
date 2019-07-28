namespace GoOut.Services.Data
{
    using Contracts;
    using Web.ViewModels.Users;
    using Mapping;
    using GoOut.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using GoOut.Data.Common.Repositories;
    using System.Collections.Generic;

    public class UsersService : IUsersService
    {
        private readonly UserManager<User> userManager;

        public UsersService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        
        public IEnumerable<UserViewModel> GetAll(bool withDeleted = false)
        {
            return this.userManager.Users.To<UserViewModel>();
        }
        public bool CreaUserAsync(CreateUserViewModel model)
        {
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };

            var result = this.userManager.CreateAsync(user, model.Password);

            if (result.Result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public bool DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                var user = this.userManager.FindByIdAsync(id).Result;

                if (user != null)
                {
                    var result = this.userManager.DeleteAsync(user).Result;
                    return result.Succeeded;
                }
            }
            return false;
        }
    }
}