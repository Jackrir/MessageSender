using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.API.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService auth;
        private readonly IMapper mapper;
        public AuthController(IAuthService auth, IMapper mapper)
        {
            this.auth = auth;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginModelRequest model)
        {
            if(ModelState.IsValid)
            {
                if(await auth.LogIn(mapper.Map<UserModel>(model)))
                {
                    return Ok();
                }
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModelRequest model)
        {
            if (ModelState.IsValid)
            {
                if (await auth.Registration(mapper.Map<UserModel>(model)))
                {
                    return Ok();
                }
                return Conflict();
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await auth.LogOut();
            return Ok();
        }
    }
}
