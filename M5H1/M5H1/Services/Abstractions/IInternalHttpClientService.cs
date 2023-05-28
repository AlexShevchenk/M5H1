using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5H1.Services.Abstractions
{
    public interface IInternalHttpClientService

    {
        public Task<HttpResponseMessage> GetAsync<TRequest>(string url, HttpMethod method, TRequest content = null)
        where TRequest : class;
        Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest content = null)
            where TRequest : class;
        public Task<TResponse> DeserializeResponse<TResponse>(HttpResponseMessage massage);
    }
}
