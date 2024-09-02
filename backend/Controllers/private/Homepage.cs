using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Interfaces;
using backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/private/homepage")]
    public class Homepage : ControllerBase
    {
        private readonly IHomepageService _homeService;
        public Homepage(IHomepageService _homeService)
        {
            this._homeService = _homeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetHomepage()
        {
            var response = await _homeService.GetHomepage();
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Data?.ToHomepageDTO());
            
        }
    }
}