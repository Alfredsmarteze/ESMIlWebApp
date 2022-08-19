using DataStructure;
using ESMIlWebApp.Models;
using ESMIlWebApp.Ultilities;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ESMIlWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        //private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
          //  _logger = logger;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            //if (!string.IsNullOrEmpty(returnUrl))
            //{
            //    return LocalRedirect(returnUrl);
            //}
            //else
            //{
            //    return View();
            //}
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            var user = new ApplicationUser { UserName = register.UserName, Email = register.Email };
            var userdata = await _userManager.CreateAsync(user, register.Password);

            if (userdata.Succeeded)
            {    
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Login", "Home");
            }

            foreach (var err in userdata.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }

            return View("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginInfo loginInfo, string returnUrl)
        {
            try
            {


                //if (ModelState.IsValid)
                //  {
                 var signMeIn = await _signInManager.PasswordSignInAsync(loginInfo.Username, loginInfo.Password,
                  loginInfo.RememberMe, false);
                //var signMeIn=    _accountRepository.Login(loginInfo, returnUrl);

                if (signMeIn.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                    return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login details");
                }
                // }
                 return View(loginInfo);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            //await _signInManager.SignOutAsync();
           // return RedirectToAction("Index", "Home");

             await  _accountRepository.Logout();
              return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }
                
    }
}