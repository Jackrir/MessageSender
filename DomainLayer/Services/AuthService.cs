using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        private readonly IMessageSenderHttpContextAccessor httpContextAccessor;

        
        public AuthService(IRepository repository, IMapper mapper, IMessageSenderHttpContextAccessor httpContextAccessor)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> LogIn(UserModel model)
        {
            User user = repository.Get<User>(x => x.Login.Equals(model.Login) && x.Password.Equals(GetHashString(model.Password)));
            if(user != null)
            {
                await Authenticate(user);
                return true;
            }
            return false;
        }

        public async Task LogOut()
        {
            await httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<bool> Registration(UserModel model)
        {
            User user = repository.Get<User>(x => x.Login.Equals(model.Login));
            if (user == null)
            {
                User newUser = mapper.Map<User>(model);
                newUser.Role = "user";
                newUser.Password = GetHashString(newUser.Password);
                await repository.AddAsync<User>(newUser);
                await Authenticate(newUser);
                return true;
            }
            return false;
        }

        private async Task Authenticate(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }

        private string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = string.Empty;
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }
    }
}
