using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BusinessLogicLayer.Services
{
    public class MessageSenderHttpContextAccessor : IMessageSenderHttpContextAccessor
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public MessageSenderHttpContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public HttpContext HttpContext => httpContextAccessor.HttpContext;

        public int Id => Convert.ToInt32(httpContextAccessor.HttpContext.User.Identity.Name);

        public string Role => httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
    }
}
