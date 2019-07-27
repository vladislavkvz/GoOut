namespace GoOut.Web.Areas.Admin.Controllers
{
    using Common;
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
    }
}