using M5H1.Dtos;
using M5H1.Dtos.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5H1.Services.Abstractions;

public interface IUserService
{
    Task<UsersListResponse> GetUsersList();

    Task<UserDto> GetUserById(int id);

    Task<UserResponseCreate> CreateUser(string name, string job);

    Task<UserResponseUpdate> UpdateUser(int id, string name, string job);

    Task<UserResponseUpdate> UpdateUserPatch(int id, string name, string job);

    Task<UserResponseCreate> DeleteUser(int id);
}