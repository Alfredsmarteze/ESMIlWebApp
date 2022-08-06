using DataStructure;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DataContextStructure;

namespace Infrastructure.Service
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ESMContext esmContext;

        public AccountRepository(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ESMContext esmContext)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.esmContext = esmContext;
        }
        public async void Register(Register register)
        {
            var user = new ApplicationUser { UserName = register.UserName, Email = register.Email };
            //var userData =  
            await userManager.CreateAsync(user, register.Password);

             
        }
        public async Task Login(LoginInfo loginIfo)
        {
            await signInManager.PasswordSignInAsync(loginIfo.Password, loginIfo.Username, loginIfo.RememberMe, false);
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }
    }
}
