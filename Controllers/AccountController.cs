using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniProject.Migrations.Context;
using UniProject.Models.BaseDto;
using UniProject.Models.Entity.Users;
using UniProject.Services.Login;
using UniProject.Services.Register;

namespace UniProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;
        public AccountController(IRegisterService registerService, ILoginService loginService)
        {
            _registerService = registerService;
            _loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(user);
            }
            var Data = await _registerService.Execute(user);
            if (Data.result)

            {
                TempData["SucsessMessage"] = Data.Message;
            }
            else
            {
                TempData["ErrorMessage"] = Data.Message;
            }

            return View(user);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(user);
            }
            var Data = await _loginService.Execute(user);
            if (Data.result)
            {
                TempData["SucsessMessage"] = Data.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = Data.Message;
            }

            return View();
            
        }
    }
}
