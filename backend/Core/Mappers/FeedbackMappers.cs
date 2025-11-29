using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Core.Entities;

namespace Core.Mappers
{
    public static class FeedbackMappers
    {
        
        public static List<FeedbacksDTO> ToFeedbackDTO(this List<Feedbacks> feedbacks)
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

        public static List<FeedbacksDTO> ToFeedbacksDTO(this List<Feedbacks> feedbacks)
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


        public static Feedbacks FromFeedbackDTO(this CreateFeedbackDTO feedback)
        {
            return new Feedbacks
            {
                Feedback = feedback.Feedback,
            };
        }
    }
}