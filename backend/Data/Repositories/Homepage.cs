using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers;
using backend.Database;
using backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Repositories
{
    public class HomepageRepository: IHomepageRepository
    {
        private readonly ApplicationDB _db;
        
        public HomepageRepository(ApplicationDB db)
        {
            _db = db;
        }

        public async Task<List<Models.Events>?> GetHomepage()
        {
            var topEvents = await _db.User_Events
                                    .GroupBy(ue => ue.Event_id)
                                    .Select(group => new{
                                                     EventId = group.Key,
                                                     Count = group.Count()
                                             })
                                    .OrderByDescending(g => g.Count)
                                    .Take(2).ToListAsync();
            if (topEvents == null)
            {
                return null;
            }
            var topEventsList = new List<Models.Events>();
            foreach (var topEvent in topEvents)
            {
                var events = await _db.Events.FindAsync(topEvent.EventId);
                if (events != null)
                {
                    topEventsList.Add(events);
                }
            }
            return topEventsList;
        }
        
    }
}