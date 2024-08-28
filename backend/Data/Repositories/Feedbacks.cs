using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Database;
using backend.Interfaces;

namespace backend.Repositories
{
    public class FeedbacksRepository: IFeedbackRepository
    {
        private readonly ApplicationDB _db;
        
        public FeedbacksRepository(ApplicationDB db)
        {
            _db = db;
        }
        
    }
}