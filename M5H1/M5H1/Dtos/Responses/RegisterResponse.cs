using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5H1.Dtos.Dtos.Responses;

public class RegisterResponse
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("token")]
    public string Token { get; set; }
}