using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<CreatedMessageModel> GetAllUserMessages();

        string GetUserMessageById(int id);

        Task AddNewMessage(MessageModel model);

        Task<int> UpdateMessage(MessageModel model);

        Task<int> DeleteMessage(int id);
    }
}
