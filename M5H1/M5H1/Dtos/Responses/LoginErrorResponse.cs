using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace M5H1.Dtos.Dtos.Responses;

public class LoginErrorResponse
{
    [JsonProperty("error")]
    public string Error { get; set; }
}