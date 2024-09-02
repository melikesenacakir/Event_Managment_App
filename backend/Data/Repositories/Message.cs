using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Database;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class MessageRepository: IMessagesRepository
    {
        private readonly ApplicationDB _db;
        
        public MessageRepository(ApplicationDB db)
        {
            _db = db;
        }

        public async Task<Messages?> CreateMessage(Messages message, Guid userID, int eventID)
        {

            var user = await _db.Users.FindAsync(userID);
            if (user == null)
            {
                return null;
            }
            var events = await _db.Events.FindAsync(eventID);
            if (events == null)
            {
                return null;
            }
            var messageUser = new Messages
            {
                Craeted_by = userID,
                Content = message.Content,
                Event_id = eventID,
                Created_at = DateTime.Now
            };
            var newMessage = await _db.Messages.AddAsync(messageUser);
            if (newMessage == null)
            {
                return null;
            }
            await _db.SaveChangesAsync();
            return message;
        }

        public async Task<List<Messages>> GetMessages()
        {
            var messages = await _db.Messages.ToListAsync();
           // var messageList = new List<Messages>();
            if (messages == null)
            {
                return null;
            }
            foreach (var message in messages)
            {
                var user = await _db.Users.FindAsync(message.Craeted_by);
                if (user == null)
                {
                    return null;
                }
                var events = await _db.Events.FindAsync(message.Event_id);
                if (events == null)
                {
                    return null;
                }
            }
            return messages;
        }
    }
}