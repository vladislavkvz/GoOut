namespace GoOut.Web.Areas.Admin.Controllers
{
    using NToastNotify;
    using ViewModels.Users;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using GoOut.Services.Data.Contracts;
    using Microsoft.AspNetCore.Authorization;

    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IToastNotification toastNotification;
        private readonly IUsersService usersService;

        public UsersController(IToastNotification toastNotification,
            IUsersService usersService)
        {
            this.toastNotification = toastNotification;
            this.usersService = usersService;
        }
        public IActionResult Index()
        {
            //Success
            toastNotification.AddSuccessToastMessage("Same for success message");
            // Success with default options (taking into account the overwritten defaults when initializing in Startup.cs)
            toastNotification.AddSuccessToastMessage("Same for success message");

            //Info
            toastNotification.AddInfoToastMessage("Same for success message");

            //Warning
            toastNotification.AddWarningToastMessage("Same for success message");

            //Error
            toastNotification.AddErrorToastMessage("Same for success message");

            var users = this.usersService.GetAll();

            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool userCreated = this.usersService.CreaUserAsync(model);

            if (!userCreated)
            {
                //TODO Log error etc.
                ModelState.AddModelError(string.Empty, "There was an error creating the user!");

                return View(model);
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return this.RedirectToAction("Index");
            }

            bool userDeleted = this.usersService.DeleteUser(id);

            if (!userDeleted)
            {
                //TODO Log error etc.
                ModelState.AddModelError(string.Empty, "There was an error deleting the user!");

            }

            return this.RedirectToAction("Index");
        }
    }
}