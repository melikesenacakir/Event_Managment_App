using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using backend.Database;
using backend.DTOs;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/private/feedbacks")]

    public class Feedbacks : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        public Feedbacks(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFeedbacks()
        {
            var feedbacks = await _feedbackService.GetFeedbacksAsync();
            if (feedbacks == null)
            {
                return NotFound(feedbacks?.Message);
            }
            return Ok(feedbacks.Data?.ToFeedbacksDTO());
        }

        [HttpGet("{event_id}")]
        public async Task<IActionResult> GetFeedback([FromRoute] int event_id)
        {
            var feedbacks = await _feedbackService.GetFeedbackAsync(event_id);
            if (!feedbacks.Success)
            {
                return NotFound(feedbacks?.Message);
            }
            return Ok(feedbacks.Data.ToFeedbackDTO());
        }

        [HttpPost("{event_id}/{user_id}")]
        public async Task<IActionResult> CreateFeedback([FromBody] CreateFeedbackDTO feedbackdto, [FromRoute] int event_id, [FromRoute] Guid user_id)
        {
            var create = await _feedbackService.CreateFeedbackAsync(feedbackdto.FromFeedbackDTO(), event_id, user_id);
            if (!create.Success)
            {
                return NotFound(create.Message);
            }
            return Ok(create.Message);
        }

       /*  [HttpGet("joined/{user_id}")]
        public async Task<IActionResult> GetUserFeedbacks([FromRoute] Guid user_id)
        {
            var feedbacks = await _feedbackService.GetFeedbacksJoinedByUserAsync(user_id);
            if (feedbacks.Data == null)
            {
                return NotFound(feedbacks.Message);
            }
            return Ok(feedbacks.Data);
        } */

         [HttpGet("user/{user_id}")]
        public async Task<IActionResult> GetUserCreatedFeedbacks([FromRoute] Guid user_id)
        {
            var feedbacks = await _feedbackService.GetFeedbacksCreatedByUserAsync(user_id);
            if (feedbacks.Data == null || !feedbacks.Success)
            {
                return NotFound(feedbacks.Message);
            }
            return Ok(feedbacks.Data?.ToFeedbacksDTO());
        }

        
    }
}