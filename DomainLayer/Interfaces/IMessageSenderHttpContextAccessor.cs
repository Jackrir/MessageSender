using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface IMessageSenderHttpContextAccessor
    {
        HttpContext HttpContext { get; }
        string Role { get; }

        int Id { get; }
    }
}
