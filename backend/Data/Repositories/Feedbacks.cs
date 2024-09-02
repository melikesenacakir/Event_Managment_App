using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Database;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class FeedbacksRepository: IFeedbackRepository
    {
        private readonly ApplicationDB _db;
        
        public FeedbacksRepository(ApplicationDB db)
        {
            _db = db;
        }

        public async Task<Feedbacks> CreateFeedback(Feedbacks feedback, Guid user_id, int event_id)
        {
            if (feedback == null || user_id == null || event_id == 0)
            {
                return null;
            }
            feedback.User_id = user_id;
            feedback.Event_id = event_id;
            await _db.Feedbacks.AddAsync(feedback);
            await _db.SaveChangesAsync();
            return feedback;
        }

        public async Task<List<Feedbacks>> GetFeedback(int id)
        {
            var feedback = await _db.Feedbacks.Where(x => x.Event_id == id).ToListAsync();
            if (feedback == null)
            {
                return null;
            }
            foreach (var f in feedback)
            {
                var user = await _db.Users.Where(x => x.ID == f.User_id).FirstOrDefaultAsync();
                f.User_name = user.Name;
            }
            return feedback;
        }

        public async Task<List<Feedbacks>> GetFeedbacks()
        {
            var feedbacks = await _db.Feedbacks.ToListAsync();
            if (feedbacks == null)
            {
                return null;
            }
            var feedbackList = new List<Feedbacks>();
            foreach (var feedback in feedbacks)
            {
                var user = await _db.Users.Where(x => x.ID == feedback.User_id).FirstOrDefaultAsync();
                var eventTitle = await _db.Events.Where(x => x.ID == feedback.Event_id).FirstOrDefaultAsync();
                var newFeedback = new Feedbacks
                {
                    ID = feedback.ID,
                    User_id = feedback.User_id,
                    User_name = feedback.User_name,
                    Event_id = feedback.Event_id,
                    Event_title = eventTitle.Title,
                    Feedback = feedback.Feedback,
                    Events = feedback.Events
                };
                feedbackList.Add(newFeedback);
            }
            return feedbackList;
        }

       public async Task<List<Feedbacks?>> GetFeedbacksCreatedByUser(Guid id) //feedbacks to events that user created
        {
            var user = await _db.Users.Where(x => x.ID == id).FirstOrDefaultAsync();
            var feedbacks = await _db.Feedbacks
                        .Include(x => x.Events)
                        .Where(x => x.User_id == id)
                        .ToListAsync();

            if (feedbacks == null)
            {
                return null;
            }

            var createdFeedbacks = new List<Feedbacks?>();

            foreach (var feedback in feedbacks)
            {
                var newFeedback = new Feedbacks
                {
                    ID = feedback.ID,
                    User_id = feedback.User_id,
                    User_name = user?.Name, 
                    Event_id = feedback.Event_id,
                    Feedback = feedback.Feedback,
                    Events = feedback.Events
                };
                createdFeedbacks.Add(newFeedback); 
            }

            return createdFeedbacks;
        }

        }

        /* public async Task<List<Feedbacks?>> GetFeedbacksJoinedByUser(Guid id)
        {
            var feedbacks = await _db.User_Events.Include(x => x.Events).Where(x => x.User_id == id).ToListAsync();
            if (feedbacks == null)
            {
                return null;
            }
            var joinedFeedbacks = new List<Feedbacks?>();
            foreach (var userEvent in feedbacks)
            {
                var feedback = _db.Feedbacks.Include(x => x.Events).Where(x => x.Events.ID == userEvent.Event_id).FirstOrDefault();
                joinedFeedbacks.Add(feedback);
            }
            return joinedFeedbacks;
        } */
}
