using M5H1.Config;
using M5H1.Dtos.Dtos.Responses;
using M5H1.Dtos;
using M5H1.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace M5H1.Services;

public class ResourceService : IRegisterService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<UserService> _logger;
    private readonly ApiOption _option;
    private readonly string _resourseApi = "api/known";

    public ResourceService(
    
        IInternalHttpClientService httpClientService,
        IOptions<ApiOption> options,
        ILogger<UserService> logger)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _option = options.Value;
    }

    public async Task<ResourseListResponse> GetReSourceList()
    {
        var services = new ServiceCollection();
        services.AddHttpClient();
        var serviceprovider = services.BuildServiceProvider(); 
        var httpClientFactoryr = serviceprovider.GetService<IHttpClientBuilder>();
        var httpClient = httpClientFactoryr.CreateClient();

        var response = await httpClient.GetAsync("https://reqres.in/api/unknown");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResourceListResponse>(content);
        }
        else if (response.SuccessStatusCode == HttpStatusCode.NotFound)
        {
            _logger.LogError($"Error");
            return null;
        }
        else
        {
            throw new Exception($"Failed to get resource list:{response.StatusCode}");
        }
        
    }

    public async Task<ResourceDto> GetResourceById(int id)
    {
        
        var result = await _httpClientService.SendAsync<BaseResponse<ResourceDto>, object>($"{_options.Host}{_resourceApi}{id}", HttpMethod.Get);

        if (result?.Data != null)
        {
            _logger.LogInformation($"Resource with id = {result.Data.Id} was found");
        }

        return result?.Data;
        
    }
}