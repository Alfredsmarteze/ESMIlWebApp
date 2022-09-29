using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IEmailRepository
    {
        public bool SendEmail(string email, string body);
    }
}
