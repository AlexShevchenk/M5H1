using M5H1.Config;
using M5H1.Dtos.Requests;
using M5H1.Dtos.Responses;
using M5H1.Dtos;
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
    public class ResourceService : IResourceService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<ResourceService> _logger;
        private readonly ApiOption _options;
        private readonly string _resourseApi = "api/unknown";

        public ResourceService(
            IInternalHttpClientService httpClientService,
            IOptions<ApiOption> options,
            ILogger<ResourceService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<ResourceDto> GetResourceById(int id)
        {
            var result = await _httpClientService.SendAsync<BaseResponse<ResourceDto>, object>($"{_options.Host}{_resourseApi}/{id}", HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"Resource with id = {result.Data.Id} was found");
            }
            else
            {
                _logger.LogInformation($"Resource with id = {id} wosn't found");
            }
            return result?.Data;
        }


        public async Task<BasePageResponse<ResourceDto>> GetResourcePage(int page)
        {
            var result = await _httpClientService.SendAsync<BasePageResponse<ResourceDto>, object>($"{_options.Host}{_resourseApi}?page={page}", HttpMethod.Get);
            if (result?.Data != null)
            {
                _logger.LogInformation($"Resource page {page} was found");
            }
            else
            {
                _logger.LogInformation($"Resource page = {page} wosn't found");
            }
            return result;
        }
    }
}