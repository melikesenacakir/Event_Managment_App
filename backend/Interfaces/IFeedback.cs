using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Services;

namespace backend.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<List<Models.Feedbacks>> GetFeedbacks();
        Task<List<Models.Feedbacks>> GetFeedback(int id);
        Task<Models.Feedbacks?> CreateFeedback(Models.Feedbacks feedback, Guid user_id, int event_id);
       // Task<List<Models.Feedbacks?>> GetFeedbacksJoinedByUser(Guid id);
        Task<List<Models.Feedbacks?>> GetFeedbacksCreatedByUser(Guid id); //created events
    }
    public interface IFeedbackService
    {
        Task<ServiceResponse<List<Models.Feedbacks>>> GetFeedbacksAsync(); //all
        Task<ServiceResponse<List<Models.Feedbacks>>> GetFeedbackAsync(int id);
        Task<ServiceResponse<Models.Feedbacks>?> CreateFeedbackAsync(Models.Feedbacks newFeedback, int event_id, Guid user_id);
       // Task<ServiceResponse<List<Models.Feedbacks?>>> GetFeedbacksJoinedByUserAsync(Guid id); //joined events
        Task<ServiceResponse<List<Models.Feedbacks?>>> GetFeedbacksCreatedByUserAsync(Guid id); //created events
    }
}