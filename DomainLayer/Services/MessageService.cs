using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using System.Threading.Tasks;
using AutoMapper;

namespace BusinessLogicLayer.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRepository repository;
        private readonly IMessageSenderHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;

        public MessageService(IRepository repository, IMessageSenderHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            this.repository = repository;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
        }

        public async Task AddNewMessage(MessageModel model)
        {
            await repository.AddAsync<Message>(new Message
            {
                UserId = httpContextAccessor.Id,
                Text = model.Text,
                Time = DateTime.UtcNow
            }); ;
        }

        public async Task<int> DeleteMessage(int id)
        {
            Message message = repository.Get<Message>(x => x.Id == id);
            if (message == null)
            {
                return 204;
            }
            else
            {
                if (httpContextAccessor.Role.Equals("admin") || httpContextAccessor.Id == message.UserId)
                {
                    await repository.DeleteAsync<Message>(message);
                    return 200;
                }
                return 403;
            }
        }

        public IEnumerable<CreatedMessageModel> GetAllUserMessages()
        {
            if (httpContextAccessor.Role.Equals("admin"))
            {
                return mapper.Map<IEnumerable<Message>, IEnumerable<CreatedMessageWithUserModel>>(repository.GetRange<Message>(x => true));
            }
            else
            {
                return mapper.Map<IEnumerable<Message>, IEnumerable<CreatedMessageModel>>(repository.GetRange<Message>(x => x.UserId == httpContextAccessor.Id));
            }
        }

        public async Task<int> UpdateMessage(MessageModel model)
        {
            Message message = repository.Get<Message>(x => x.Id == model.Id);
            if(message == null)
            {
                await AddNewMessage(model);
                return 201;
            }
            else
            {
                if(httpContextAccessor.Role.Equals("admin") || httpContextAccessor.Id == message.UserId)
                {
                    message.Text = model.Text;
                    await repository.UpdateAsync<Message>(message);
                    return 200;
                }
                return 403;
            }
        }
    }
}
