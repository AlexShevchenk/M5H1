using M5H1.Dtos;
using M5H1.Config;
using M5H1.Dtos.Requests;
using M5H1.Dtos.Responses.Account;
using M5H1.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M5H1.Dtos.Responses.Users;
using M5H1.Dtos.Responses;

namespace M5H1.Services
{
    internal class UserService : IUserService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<UserService> _logger;
        private readonly ApiOption _options;
        private readonly string _userApi = "api/users";

        public UserService(
            IInternalHttpClientService httpClientService,
            IOptions<ApiOption> options,
            ILogger<UserService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var result = await _httpClientService.SendAsync<BaseResponse<UserDto>, object>($"{_options.Host}{_userApi}/{id}", HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"User with id = {result.Data.Id} was found");
            }
            else
            {
                _logger.LogInformation($"User with id = {id} wosn't found");
            }
            return result?.Data;

        }

        public async Task<UserResponseCreate> CreateUser(string name, string job)
        {
            var result = await _httpClientService.SendAsync<UserResponseCreate, UserRequest>(
                $"{_options.Host}{_userApi}/",
                HttpMethod.Post,
                new UserRequest()
                {
                    Job = job,
                    Name = name
                });

            if (result != null)
            {
                _logger.LogInformation($"User with id = {result?.Id} was created");
            }

            return result;
        }

        public async Task<BasePageResponse<UserDto>> GetUsersPage(int page)
        {
            var result = await _httpClientService.SendAsync<BasePageResponse<UserDto>, object>($"{_options.Host}{_userApi}?page={page}", HttpMethod.Get);
            if (result?.Data != null)
            {
                _logger.LogInformation($"User page {page} was found");
            }
            else
            {
                _logger.LogInformation($"User page {page} wosn't found");
            }
            return result;
        }

        public async Task<UserResponseUpdate> PutUpdateUser(int id, string name, string job)
        {

            var result = await _httpClientService.SendAsync<UserResponseUpdate, UserRequest>(
                $"{_options.Host}{_userApi}/{id}",
                HttpMethod.Put,
                new UserRequest()
                {
                    Job = job,
                    Name = name
                });
            if (result != null)
            {
                _logger.LogInformation($"User with id = {id} was put");
            }
            else
            {
                _logger.LogInformation($"User with id = {id} wosn't found");
            }

            return result;
        }

        public async Task<UserResponseUpdate> PatchUpdateUser(int id, string name, string job)
        {
            var result = await _httpClientService.SendAsync<UserResponseUpdate, UserRequest>(
                $"{_options.Host}{_userApi}/{id}",
                HttpMethod.Patch,
                new UserRequest()
                {
                    Job = job,
                    Name = name
                });
            if (result != null)
            {
                _logger.LogInformation($"User with id = {id} was patch");
            }
            else
            {
                _logger.LogInformation($"User with id = {id} wosn't found");
            }
            return result;
        }

        public async Task DeleteUser(int id)
        {
            var result = await _httpClientService.GetAsync<object>(
                $"{_options.Host}{_userApi}/{id}",
                HttpMethod.Delete, null);

            if (((int)result.StatusCode) == 20)
            {
                _logger.LogInformation($"User with id = {id} was delete");
            }
            else
            {
                _logger.LogInformation($"User with id = {id} wosn't found");
            }


        }
    }
}
