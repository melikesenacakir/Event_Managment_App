using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Database;
using Core.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class HomepageRepository: IHomepageRepository
    {
        private readonly ApplicationDB _db;
        
        public HomepageRepository(ApplicationDB db)
        {
            _db = db;
        }

        public async Task<List<Events>?> GetHomepage()
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
            var topEventsList = new List<Events>();
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