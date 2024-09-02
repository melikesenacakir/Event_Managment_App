using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Services;

namespace backend.Interfaces
{
    public interface IMessagesRepository
    {
        Task<List<Models.Messages>> GetMessages();
        Task<Models.Messages?> CreateMessage(Models.Messages message, Guid userId,int eventId);
    }
    public interface IMessagesService
    {
        Task<ServiceResponse<List<Models.Messages>>> GetMessagesAsync();
        Task<ServiceResponse<Models.Messages>?> CreateMessageAsync(Models.Messages newMessage, Guid userId,int eventId);
    }
}