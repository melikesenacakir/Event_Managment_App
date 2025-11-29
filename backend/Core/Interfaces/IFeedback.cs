using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Models;

namespace Core.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<List<Feedbacks>> GetFeedbacks();
        Task<List<Feedbacks>> GetFeedback(int id);
        Task<Feedbacks?> CreateFeedback(Feedbacks feedback, Guid user_id, int event_id);
       // Task<List<Feedbacks?>> GetFeedbacksJoinedByUser(Guid id);
        Task<List<Feedbacks?>> GetFeedbacksCreatedByUser(Guid id); //created events
    }
    public interface IFeedbackService
    {
        Task<ServiceResponse<List<Feedbacks>>> GetFeedbacksAsync(); //all
        Task<ServiceResponse<List<Feedbacks>>> GetFeedbackAsync(int id);
        Task<ServiceResponse<Feedbacks>?> CreateFeedbackAsync(Feedbacks newFeedback, int event_id, Guid user_id);
       // Task<ServiceResponse<List<Feedbacks?>>> GetFeedbacksJoinedByUserAsync(Guid id); //joined events
        Task<ServiceResponse<List<Feedbacks?>>> GetFeedbacksCreatedByUserAsync(Guid id); //created events
    }
}