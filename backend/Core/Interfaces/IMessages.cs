using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Models;

namespace Core.Interfaces
{
    public interface IMessagesRepository
    {
        Task<List<Messages>> GetMessages();
        Task<Messages?> CreateMessage(Messages message, Guid userId,int eventId);
    }
    public interface IMessagesService
    {
        Task<ServiceResponse<List<Messages>>> GetMessagesAsync();
        Task<ServiceResponse<Messages>?> CreateMessageAsync(Messages newMessage, Guid userId,int eventId);
    }
}