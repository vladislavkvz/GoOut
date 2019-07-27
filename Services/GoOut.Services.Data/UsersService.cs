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
    }
}