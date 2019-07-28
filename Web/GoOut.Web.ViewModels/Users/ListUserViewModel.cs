namespace GoOut.Web.ViewModels.Users
{
    using Data.Models;
    using Services.Mapping;

    public class ListUserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsDeleted { get; set; }
    }
}