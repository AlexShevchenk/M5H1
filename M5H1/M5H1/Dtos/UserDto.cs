﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace M5H1.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        [JsonProperty(PropertyName ="first_name")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName ="last_name")]
        public string LastName { get; set; }
        public string Avatar { get; set; }
    }
}
