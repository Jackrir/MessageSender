using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.API.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService service;
        private readonly IMapper mapper;
        public MessageController(IMessageService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<CreatedMessageModel> messages = service.GetAllUserMessages();
            if (messages.Count() == 0)
            {
                return NoContent();
            }
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public ContentResult GetHtmlMessage(int id)
        {
            string message = service.GetUserMessageById(id);
            if (message == null)
            {
                message = "Empty";
            }
            return base.Content(message, "text/html; charset=utf-8");
        }

        [HttpPost]
        public async Task<IActionResult> Send([FromBody]NewMessageRequest newMessage)
        {
            if(ModelState.IsValid)
            {
                await service.AddNewMessage(mapper.Map<MessageModel>(newMessage));
                return StatusCode(201);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditMessageRequest editMessage)
        {
            if (ModelState.IsValid)
            {
                return StatusCode(await service.UpdateMessage(mapper.Map<MessageModel>(editMessage)));
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return StatusCode(await service.DeleteMessage(id));
        }
    }
}
