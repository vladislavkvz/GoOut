namespace GoOut.Services.Data
{
    using Contracts;
    using Web.ViewModels.Users;
    using Mapping;
    using GoOut.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using GoOut.Data.Common.Repositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UsersService : IUsersService
    {
        private readonly UserManager<User> userManager;

        public UsersService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        
        public IEnumerable<ListUserViewModel> GetAll(bool withDeleted = false)
        {
            return this.userManager.Users.To<ListUserViewModel>();
        }

        public UpdateUserViewModel GetUserById(string id)
        {
            var user = this.userManager.FindByIdAsync(id).Result;

            var model = new UpdateUserViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            };

            return model;
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

        public bool UpdateUserAsync(string id,UpdateUserViewModel model)
        {
            var user = this.userManager.FindByIdAsync(id).Result;

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;

            var result = this.userManager.UpdateAsync(user);

            if (result.Result.Succeeded)
            {
                return true;
            }
            return false;
        }
        
        public bool DeleteUser(string id)
        {
            if (!string.IsNullOrEmpty(id))
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