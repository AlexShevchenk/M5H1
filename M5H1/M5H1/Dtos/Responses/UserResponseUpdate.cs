using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace M5H1.Dtos.Dtos.Responses;

public class UserResponseUpdate:UserResponse
{
    public DateTimeOffset UpdatedAt { get; set; }
}