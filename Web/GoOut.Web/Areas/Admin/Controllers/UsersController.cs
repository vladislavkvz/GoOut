namespace GoOut.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using NToastNotify;
    using ViewModels.Users;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using GoOut.Services.Data.Contracts;

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

        [HttpGet]
        public IActionResult Index()
        {
            var users = this.usersService.GetAll().Where(u=>u.Email != User.Identity.Name);

            return View(users);
        }

        [HttpGet]
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
                this.toastNotification.AddErrorToastMessage("There was a problem creating the user!");

                return View(model);
            }

            this.toastNotification.AddSuccessToastMessage("User was successfully created!");
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return this.NotFound();
            }

            UpdateUserViewModel model = this.usersService.GetUserById(id);

            if (model == null)
            {
                return this.NotFound();
            }
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool userUpdated = this.usersService.UpdateUserAsync(model.Id, model);

            if (!userUpdated)
            {
                //TODO Log error etc.
                this.toastNotification.AddErrorToastMessage("There was a problem updating the user!");

                return View(model);
            }

            this.toastNotification.AddSuccessToastMessage("User was successfully updated!");
            return this.RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return this.NotFound();
            }

            bool userDeleted = this.usersService.DeleteUser(id);

            if (!userDeleted)
            {
                //TODO Log error etc.
                this.toastNotification.AddErrorToastMessage("There was a problem deleting the user!");

            }

            this.toastNotification.AddSuccessToastMessage("User was successfully deleted!");
            return this.RedirectToAction("Index");
        }
    }
}