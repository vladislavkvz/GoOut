namespace GoOut.Services.Data.Contracts
{
    using Web.ViewModels.Users;
    using System.Collections.Generic;

    public interface IUsersService
    {
        IEnumerable<UserViewModel> GetAll(bool withDeleted = false);
    }
}