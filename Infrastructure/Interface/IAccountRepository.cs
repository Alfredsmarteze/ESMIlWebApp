using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IAccountRepository
    {
        void Register(Register register);
        Task Logout();
        Task Login(LoginInfo loginIfo);

    }
}
