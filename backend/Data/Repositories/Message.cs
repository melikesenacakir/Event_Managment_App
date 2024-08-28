using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Database;
using backend.Interfaces;

namespace backend.Repositories
{
    public class MessageRepository: IMessagesRepository
    {
        private readonly ApplicationDB _db;
        
        public MessageRepository(ApplicationDB db)
        {
            _db = db;
        }
        
    }
}