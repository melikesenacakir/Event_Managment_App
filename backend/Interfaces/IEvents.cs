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
        Task<List<Models.User_Events?>> GetEventsCreatedByUser(Guid id); 
        Task<List<Models.User_Events?>> GetEventsByUserParticipated(int id); 
        Task<List<Models.User_Events>?> ParticipateEvent(int id,Models.Joined_Events joined);

    }
    public interface IEventsService
    {
        Task<ServiceResponse<List<Models.Events>>> GetEventsAsync();
        Task<ServiceResponse<Models.User_Events>> GetEventAsync(int id);
        Task<ServiceResponse<Models.Events>?> CreateEventAsync(Models.Events newEvent);
        Task<ServiceResponse<List<Models.Events>?>?> UpdateEventAsync(Models.Events update,int id);
        Task<ServiceResponse<List<Models.User_Events?>>> GetEventsCreatedByUserAsync(Guid id); //kullanıcının oluşturduğu etkinlikleri getirir
        Task<ServiceResponse<List<Models.User_Events?>>> GetEventsByUserParticipatedAsync(int id); //kullanıcının katıldığı etkinlikleri getirir
        Task<ServiceResponse<List<Models.Events>?>> ParticipateEventAsync(int event_id, Models.Joined_Events joined);
    }
}