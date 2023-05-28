using M5H1.Dtos;
using M5H1.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5H1.Services.Abstractions
{
    public interface IResourceService
    {
        Task<ResourceDto> GetResourceById(int id);
        Task<BasePageResponse<ResourceDto>> GetResourcePage(int id);
    }
}
