using DataContextStructure;
using DataStructure;
using DataStructure.ViewModelAccount;
using ESMIlWebApp.Models;
using ESMIlWebApp.Ultilities;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ESMIlWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IEmailRepository _emailRepository;
        private readonly ESMContext _eSMContext;

        public AccountController(ILogger<AccountController> logger, UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, IAccountRepository accountRepository, IEmailRepository emailRepository,
            ESMContext eSMContext)
        {
            this._emailRepository=emailRepository;
            this._accountRepository = accountRepository;
           this._logger = logger;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._eSMContext = eSMContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPassword forgotPassword)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(forgotPassword.Email);
                if (user !=null && await _userManager.IsEmailConfirmedAsync(user))
                {
                    var token=await _userManager.GeneratePasswordResetTokenAsync(user);
                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { email = forgotPassword.Email, token = token }, Request.Scheme);
                    if (passwordResetLink !=null)
                    {
                        _emailRepository.SendEmail(forgotPassword.Email, passwordResetLink);
                        return View("ForgotPasswordConfirmation");
                    }
                }
                return View("ForgotPasswordConfirmation");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel reset)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(reset.Email);
                if (user !=null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, reset.Token, reset.Password);
                    if (result.Succeeded)
                    {
                        return View("ResetPasswordConfirmation");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(reset);
                }
                return View("ResetPasswordConfirmation");   
            }
            return View(reset);
        }
        
        [HttpGet]
        public  async Task<IActionResult> ResetPassword(string token, string email)
        {
           if (token==null || email==null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            
            var user = email;
            var usern=await _userManager.FindByEmailAsync(user);
            var tokenn = await _userManager.GeneratePasswordResetTokenAsync(usern);
            return View();
        }

        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
           return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            var user = new ApplicationUser { UserName = register.UserName, Email = register.Email };
            var userEmaill=  _accountRepository.EmailExist(register);
            if (userEmaill !=null)
            {
                ViewBag.MailExist = $"This Email {register.Email} cannot be used becuase it exist already";
                return View();
            }
            
            var userdata = await _userManager.CreateAsync(user, register.Password );

            if (userdata.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action("ConfirmEmail", "Account", new
                {
                    Id = user.Id,
                    token = token
                }, Request.Scheme);
                if (confirmationLink != null)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _emailRepository.SendEmail(user.Email, confirmationLink);
                    return RedirectToAction("MailSent", "Account");
                }
            }

            foreach (var err in userdata.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }
            return View();
        }

        public IActionResult MailSent()
        {
            ViewBag.mailSent=$"Mail has been sent to the email address you provided. Check the mail to confirm the email address.";
            return View();        
        }
        public async Task<IActionResult> ConfirmEmail(string id, string token)
        {
            if (id !=null & token!=null)
            {
              var userId=  await _userManager.FindByIdAsync(id);
              var result=  await _userManager.ConfirmEmailAsync(userId, token);
                if (result.Succeeded)
                {
                    return View();
                }
            }
            return View();
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
             await  _accountRepository.Logout();
             return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }
                
    }
}