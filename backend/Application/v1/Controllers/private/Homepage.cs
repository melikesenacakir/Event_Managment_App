
using Core.Interfaces;
using Core.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Application.v1.Controllers
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