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
        Task<bool> LogIn(UserModel model);
        Task<bool> Registration(UserModel model);
        Task LogOut();
    }
}
