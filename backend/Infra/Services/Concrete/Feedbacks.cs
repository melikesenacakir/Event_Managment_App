using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Core.Entities;

namespace Infra.Services.Concrete
{
    public class FeedbackServices : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackServices(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public async Task<ServiceResponse<Feedbacks>?> CreateFeedbackAsync(Feedbacks newFeedback, int event_id, Guid user_id)
        {
            var feedback = await _feedbackRepository.CreateFeedback(newFeedback, user_id, event_id);
            if (feedback == null)
            {
                return new ServiceResponse<Feedbacks>
                {
                    Success = false,
                    Message = "Failed to create feedback",
                    Data = null
                };
            }
            return new ServiceResponse<Feedbacks>
            {
                Success = true,
                Message = "Feedback created successfully",
                Data = feedback
            };
        }

        public async Task<ServiceResponse<List<Feedbacks>>> GetFeedbackAsync(int id)
        {
            var feedback = await _feedbackRepository.GetFeedback(id);
            if (feedback == null || feedback.Count == 0 || !feedback.Any())
            {
                return new ServiceResponse<List<Feedbacks>>
                {
                    Success = false,
                    Message = "Feedback not found",
                    Data = null
                };
            }
            return new ServiceResponse<List<Feedbacks>>
            {
                Success = true,
                Message = "Feedback found",
                Data = feedback
            };
        }

        public async Task<ServiceResponse<List<Feedbacks>>> GetFeedbacksAsync()
        {
            var feedbacks = await _feedbackRepository.GetFeedbacks();
            if (feedbacks == null)
            {
                return new ServiceResponse<List<Feedbacks>>
                {
                    Success = false,
                    Message = "No feedbacks found",
                    Data = null
                };
            }
            return new ServiceResponse<List<Feedbacks>>
            {
                Success = true,
                Message = "Feedbacks found",
                Data = feedbacks
            };

        }

        public async Task<ServiceResponse<List<Feedbacks?>>> GetFeedbacksCreatedByUserAsync(Guid id)
        {
            var feedbacks = await _feedbackRepository.GetFeedbacksCreatedByUser(id);
            if (feedbacks == null || feedbacks.Count == 0 || !feedbacks.Any()) 
            {
                return new ServiceResponse<List<Feedbacks?>>
                {
                    Success = false,
                    Message = "No feedbacks found",
                    Data = null
                };
            }
            return new ServiceResponse<List<Feedbacks?>>
            {
                Success = true,
                Message = "Feedbacks found",
                Data = feedbacks
            };
        }

       /*  public async Task<ServiceResponse<List<Feedbacks?>>> GetFeedbacksJoinedByUserAsync(Guid id)
        {
            var feedbacks = await _feedbackRepository.GetFeedbacksJoinedByUser(id);
            if (feedbacks == null)
            {
                return new ServiceResponse<List<Feedbacks?>>
                {
                    Success = false,
                    Message = "No feedbacks found",
                    Data = null
                };
            }
            return new ServiceResponse<List<Feedbacks?>>
            {
                Success = true,
                Message = "Feedbacks found",
                Data = feedbacks
            };
        } */
    }
}