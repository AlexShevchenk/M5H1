using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace M5H1.Dtos.Dtos.Responses;

public class UserPesponseCreate
{
    public int Id { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
}