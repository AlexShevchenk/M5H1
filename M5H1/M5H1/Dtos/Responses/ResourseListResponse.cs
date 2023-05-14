using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace M5H1.Dtos.Dtos.Responses;

public class ResourseListResponse
{
    [JsonProperty("data")]
    public List<ResourceDto> Data { get; set; }
}