namespace GoOut.Web.ViewModels.Users
{
    using Data.Models;
    using Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CreateUserViewModel : IMapTo<User>
    {
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

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}