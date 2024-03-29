﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace M5H1.Dtos.Requests
{
    public class AccountRequest
    {
        [JsonProperty(PropertyName="email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
