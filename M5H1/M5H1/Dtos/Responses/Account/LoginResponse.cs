using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M5H1.Dtos.Responses.Account.Abstractions;

namespace M5H1.Dtos.Responses.Account
{
    public class LoginResponse:IAccountResponse
    {
        public string? Token { get; set; }
        public string? Error { get; set; }
    }
}
