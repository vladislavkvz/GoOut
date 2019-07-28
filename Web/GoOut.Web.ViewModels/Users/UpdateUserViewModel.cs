namespace GoOut.Web.ViewModels.Users
{
    using Data.Models;
    using Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class UpdateUserViewModel : IMapTo<User>
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter a username for current user.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter an email.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter user's first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your user's last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}