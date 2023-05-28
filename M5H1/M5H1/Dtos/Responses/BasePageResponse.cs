using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using M5H1.Dtos.Responses;
using Newtonsoft.Json;

namespace M5H1.Dtos.Responses
{
    public class BasePageResponse<T> : BaseResponse<IEnumerable<T>>
      where T : class
    {
        public int Page { get; set; }
        [JsonProperty(PropertyName = "per_page")]
        public int PerPage { get; set; }
        public int Total { get; set; }
        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }


    }
}
