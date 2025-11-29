using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Models;

namespace Core.Interfaces
{
    public interface IEventsRepository
    {
        Task<List<Events>?> UpdateEvent(Events update,int id);
        Task<List<Events>> GetEvents();
        Task<User_Events> GetEvent(int id);
        Task<Events?> CreateEvent(Events events);
        Task<List<User_Events?>> GetEventsCreatedByUser(Guid id); 
        Task<List<User_Events?>> GetEventsByUserParticipated(int id); 
        Task<List<User_Events>?> ParticipateEvent(int id,Joined_Events joined);

    }
    public interface IEventsService
    {
        Task<ServiceResponse<List<Events>>> GetEventsAsync();
        Task<ServiceResponse<User_Events>> GetEventAsync(int id);
        Task<ServiceResponse<Events>?> CreateEventAsync(Events newEvent);
        Task<ServiceResponse<List<Events>?>?> UpdateEventAsync(Events update,int id);
        Task<ServiceResponse<List<User_Events?>>> GetEventsCreatedByUserAsync(Guid id); //kullanıcının oluşturduğu etkinlikleri getirir
        Task<ServiceResponse<List<User_Events?>>> GetEventsByUserParticipatedAsync(int id); //kullanıcının katıldığı etkinlikleri getirir
        Task<ServiceResponse<List<Events>?>> ParticipateEventAsync(int event_id, Joined_Events joined);
    }
}