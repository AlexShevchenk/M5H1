using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M5H1.Dtos;
using M5H1.Dtos.Responses;
using M5H1.Dtos.Responses.Users;

namespace M5H1.Services.Abstractions
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(int id);
        Task<UserResponseCreate> CreateUser(string name, string job);
        Task<BasePageResponse<UserDto>> GetUsersPage(int id);
        Task<UserResponseUpdate> PutUpdateUser(int id, string name, string job);
        Task<UserResponseUpdate> PatchUpdateUser(int id, string name, string job);
        Task DeleteUser(int id);
    }
}
