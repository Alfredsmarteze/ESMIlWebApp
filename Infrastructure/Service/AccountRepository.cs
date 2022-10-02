using DataStructure;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DataContextStructure;
using System.Reflection.Metadata.Ecma335;

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
        public async Task<SignInResult> Login(LoginInfo loginIfo, string returnUrl)
        {
            var re=  await signInManager.PasswordSignInAsync(loginIfo.Password, loginIfo.Username, loginIfo.RememberMe, false);
          //  if (re.Succeeded)
          //  {
          //      return re;
          //  }
            return re; ;    
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public IQueryable EmailExist(Register register)
        {
            var emailExist=   esmContext.Users.Where(s => s.Email == register.Email);
            if (emailExist.Any())
            {
                return emailExist;
            }
            return null ;
        }

    }
}
