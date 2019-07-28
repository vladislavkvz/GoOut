namespace GoOut.Services.Data.Contracts
{
    using Web.ViewModels.Users;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IUsersService
    {
        IEnumerable<ListUserViewModel> GetAll(bool withDeleted = false);
        UpdateUserViewModel GetUserById(string id);
        bool CreaUserAsync(CreateUserViewModel model);
        bool UpdateUserAsync(string id, UpdateUserViewModel model);
        bool DeleteUser(string id);
    }
}