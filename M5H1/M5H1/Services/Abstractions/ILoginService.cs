using M5H1.Dtos.Responses.Account;
using M5H1.Dtos.Responses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5H1.Services.Abstractions
{
    public interface ILoginService
    {
        Task<LoginResponse> Login(string email, string password);
    }
}
