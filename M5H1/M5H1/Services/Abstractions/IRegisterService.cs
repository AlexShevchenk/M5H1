using M5H1.Dtos.Responses.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5H1.Services.Abstractions
{
    public interface IRegisterService
    {
        Task<RegisterResponse> Register (string email, string password);
    }
}
