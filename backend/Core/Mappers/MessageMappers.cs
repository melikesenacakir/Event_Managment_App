using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Core.Entities;

namespace Core.Mappers
{
    public static class MessageMappers
    {
        public static List<MessageDTO> ToMessageDTO(this List<Messages> users){
            var MessageList = new List<MessageDTO>();
                foreach (var user in users)
                {
                   var message= new MessageDTO
                    {
                        Content = user.Content,
                        Created_at = user.Created_at.ToString(),
                        Created_by = user.Craeted_by.ToString(),
                        Event_id = user.Event_id,
                    };
                    MessageList.Add(message);
                 }
            return MessageList;
        } 

        public static Messages FromMessageDTO(this CreateMessagesDTO user){
            return new Messages
            {
                Content = user.Content,
                
            };
        }
    }
}