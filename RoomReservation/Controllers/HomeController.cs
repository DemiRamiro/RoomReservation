using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomReservation.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoomReservation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IGreeter _greeter;

        public HomeController(IGreeter greeter)
        {
            _greeter = greeter;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.Greet = _greeter.GreetGuest();
            return View();
        }
    }
}