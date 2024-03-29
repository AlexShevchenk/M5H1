﻿using M5H1.Dtos;
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

namespace M5H1.Services
{
    internal class RegisterService : IRegisterService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<RegisterService> _logger;
        private readonly ApiOption _options;
        private readonly string _registerApi = "api/register";

        public RegisterService(
            IInternalHttpClientService httpClientService,
            IOptions<ApiOption> options,
            ILogger<RegisterService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<RegisterResponse> Register(string email, string password)
        {
            var result = await _httpClientService.GetAsync<AccountRequest>(

            $"{_options.Host}{_registerApi}/",
            HttpMethod.Post,
            new AccountRequest()
            {
                Email = email,
                Password = password
            });
            var response = await _httpClientService.DeserializeResponse<RegisterResponse>(result);
            if (((int)result.StatusCode) == 200)
            {
                _logger.LogInformation($"User {email} was register");
            }
            else if (((int)result.StatusCode) == 400)
            {
                _logger.LogInformation(response.Error);
            }

            return response;


        }
    }
} 
