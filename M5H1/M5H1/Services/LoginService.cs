using M5H1.Config;
using M5H1.Dtos.Responses;
using M5H1.Dtos;
using M5H1.Dtos.Responses.Account;
using M5H1.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M5H1.Dtos.Requests;
using M5H1.Dtos.Responses.Users;
using System.Xml.Linq;

namespace M5H1.Services
{
    public class LoginService : ILoginService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<LoginService> _logger;
        private readonly ApiOption _options;
        private readonly string _loginApi = "api/login";

        public LoginService(
            IInternalHttpClientService httpClientService,
            IOptions<ApiOption> options,
            ILogger<LoginService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<LoginResponse> Login(string email, string password)
        {
            var result = await _httpClientService.GetAsync<AccountRequest>(
           $"{_options.Host}{_loginApi}/",
           HttpMethod.Post,
           new AccountRequest()
           {
               Email = email,
               Password = password
           });
            var response = await _httpClientService.DeserializeResponse<LoginResponse>(result);
            if (((int)result.StatusCode) == 200)
            {
                _logger.LogInformation($"User {email} was login");
            }
            else if(((int)result.StatusCode) == 400)
            {

                _logger.LogInformation(response.Error);
            }

            return response;

        }

    }
}