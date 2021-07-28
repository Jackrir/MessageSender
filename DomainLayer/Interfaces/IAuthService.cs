using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAuthService
    {
        Task<bool> LogIn(UserModel model, HttpContext context);
        Task<bool> Registration(UserModel model, HttpContext context);
        Task LogOut(HttpContext context);
    }
}
