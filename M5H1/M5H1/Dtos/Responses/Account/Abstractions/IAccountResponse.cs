﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5H1.Dtos.Responses.Account.Abstractions
{
    public interface IAccountResponse
    {
        string? Error { get; set; }
    }
}
