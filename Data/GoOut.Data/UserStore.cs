namespace GoOut.Data
{
    using Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class UserStore : UserStore<User, Role, DbContext>
    {
        public UserStore(DbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }

        protected override IdentityUserRole<string> CreateUserRole(User user, Role role)
        {
            return new IdentityUserRole<string> { RoleId = role.Id, UserId = user.Id };
        }
    }
}