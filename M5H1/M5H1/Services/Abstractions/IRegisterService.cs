using M5H1.Dtos.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace M5H1.Services.Abstractions;

public interface IRegisterService
{
    Task<RegisterResponse> RegisterUser(string email, string password);

    Task<string> RegisterUserMissPassword(string email);
}