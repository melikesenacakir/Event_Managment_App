using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Core.Entities;

namespace Infra.Services.Concrete
{
    public class Message : IMessagesService
    {
        private readonly IMessagesRepository _messagesRepository;
        public Message(IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }

        public async Task<ServiceResponse<Messages>> CreateMessageAsync(Messages newMessage, Guid userID, int eventID)
        {
           newMessage.Created_at = DateTime.Now;
           if (newMessage.Content == null)
           {
               return new ServiceResponse<Messages>
               {
                   Success = false,
                   Message = "Message content is required",
                   Data = null
               };
           }
           var message = await _messagesRepository.CreateMessage(newMessage,userID,eventID);
              if (message == null)
              {
                return new ServiceResponse<Messages>
                {
                     Success = false,
                     Message = "Failed to create message",
                     Data = null
                };
              }
                return new ServiceResponse<Messages>
                {
                    Success = true,
                    Message = "Message created successfully",
                    Data = message
                };
        }

        public async Task<ServiceResponse<List<Messages>>> GetMessagesAsync()
        {
            var messages = await _messagesRepository.GetMessages();
            if (messages == null)
            {
                return new ServiceResponse<List<Messages>>
                {
                    Success = false,
                    Message = "Messages not found",
                    Data = null
                };
            }
            return new ServiceResponse<List<Messages>>
            {
                Success = true,
                Message = "Messages found",
                Data = messages
            };
        }
    }
}