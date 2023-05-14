using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5H1.Dtos.Dtos.Responses
{
    public class BaseResponse<T>
        where T : class
    {
        public T Data { get; set; }

        public SupportDto Support { get; set; }
    }
}