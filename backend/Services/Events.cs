using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers;
using backend.Interfaces;

namespace backend.Services
{
    public class EventsServices : IEventsService
    {
        private readonly IEventsRepository _eventsRepo;
        public EventsServices(IEventsRepository eventsRepo)
        {
            _eventsRepo = eventsRepo;
        }

        public async Task<ServiceResponse<Models.User_Events>> GetEventAsync(int id)
        {
            var events = await _eventsRepo.GetEvent(id);
            if (events == null)
            {
                return await Task.FromResult(new ServiceResponse<Models.User_Events>()
                {
                    Success = false,
                    Data = null,
                    Message = "Event not found",
                });
            }
            return await Task.FromResult(new ServiceResponse<Models.User_Events>()
            {
                Success = true,
                Data = events,
                Message = "Event found",
            });
        }

        public async Task<ServiceResponse<List<Models.Events>>> GetEventsAsync()
        {
            var events = await _eventsRepo.GetEvents();
            if (events == null)
            {
                return await Task.FromResult(new ServiceResponse<List<Models.Events>>()
                {
                    Success = false,
                    Data = null,
                    Message = "No events found",
                });
            }
            return await Task.FromResult(new ServiceResponse<List<Models.Events>>()
            {
                Success = true,
                Data = events,
                Message = "Events found",
            });
        }
        public async Task<ServiceResponse<Models.Events>?> CreateEventAsync(Models.Events newEvent)
        {
            var events = await _eventsRepo.CreateEvent(newEvent);
            if (events == null)
            {
                return await Task.FromResult(new ServiceResponse<Models.Events>()
                {
                    Success = false,
                    Data = null,
                    Message = "Event couldn't be created",
                });
            }
            return await Task.FromResult(new ServiceResponse<Models.Events>()
            {
                Success = true,
                Data = events,
                Message = "Event created",
            });
        }

        public Task<ServiceResponse<List<Models.Events>?>> UpdateEventAsync(Models.Events update, int id)
        {
            var events = _eventsRepo.UpdateEvent(update, id);
            if (events == null)
            {
                return Task.FromResult(new ServiceResponse<List<Models.Events>?>()
                {
                    Success = false,
                    Data = null,
                    Message = "Event couldn't be updated",
                });
            }
            return Task.FromResult(new ServiceResponse<List<Models.Events>?>()
            {
                Success = true,
                Data = events.Result,
                Message = "Event updated",
            });
        }
    }
}