namespace GoOut.Web.Areas.Admin.Controllers
{
    using ViewModels.Users;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using GoOut.Services.Data.Contracts;
    using Microsoft.AspNetCore.Authorization;

    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        public IActionResult Index()
        {
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