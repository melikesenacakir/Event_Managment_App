using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs;

namespace backend.Mappers
{
    public static class FeedbackMappers
    {
        
        public static List<FeedbacksDTO> ToFeedbackDTO(this List<Models.Feedbacks> feedbacks)
        {
             var feedbacksDTO = new List<FeedbacksDTO>();
            foreach (var feedback in feedbacks)
            {
                var feedbackDTO = new FeedbacksDTO
                {
                    Feedback = feedback.Feedback,
                    Event_id = feedback.Event_id,
                    Event_title =feedback.Event_title,
                    User_name = feedback.User_name
                };
                feedbacksDTO.Add(feedbackDTO);
            }
            return feedbacksDTO;
        }

        public static List<FeedbacksDTO> ToFeedbacksDTO(this List<Models.Feedbacks> feedbacks)
        {
            var feedbacksDTO = new List<FeedbacksDTO>();

            foreach (var feedback in feedbacks)
            {
                var feedbackDTO = new FeedbacksDTO
                {
                    Feedback = feedback.Feedback,
                    Event_id = feedback.Event_id,
                    Event_title =feedback.Event_title,
                    User_name = feedback.User_name
                };
                feedbacksDTO.Add(feedbackDTO);
            }
            return feedbacksDTO;
        }


        public static Models.Feedbacks FromFeedbackDTO(this CreateFeedbackDTO feedback)
        {
            return new Models.Feedbacks
            {
                Feedback = feedback.Feedback,
            };
        }
    }
}