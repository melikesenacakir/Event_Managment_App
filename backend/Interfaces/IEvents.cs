using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Services;

namespace backend.Interfaces
{
    public interface IEventsRepository
    {
        Task<List<Models.Events>?> UpdateEvent(Models.Events update,int id);
        Task<List<Models.Events>> GetEvents();
        Task<Models.User_Events> GetEvent(int id);
        Task<Models.Events?> CreateEvent(Models.Events events);

    }
    public interface IEventsService
    {
        Task<ServiceResponse<List<Models.Events>>> GetEventsAsync();
        Task<ServiceResponse<Models.User_Events>> GetEventAsync(int id);
        Task<ServiceResponse<Models.Events>?> CreateEventAsync(Models.Events newEvent);
        Task<ServiceResponse<List<Models.Events>?>?> UpdateEventAsync(Models.Events update,int id);
    }
}