using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Core.Entities;

namespace Infra.Services.Concrete
{
    public class HomepageService: IHomepageService
    {
        private readonly IHomepageRepository _homeRepo;
        private readonly IRedisCacheService _redisCacheService;
        public HomepageService(IHomepageRepository homeRepo, IRedisCacheService redisCacheService)
        {
            _homeRepo = homeRepo;
            _redisCacheService = redisCacheService;
        }


        public async Task<ServiceResponse<List<Events>>> GetHomepage(){
            var cache = await _redisCacheService.GetAsync<List<Events>>("homepage");
            if (cache != null)
            {
                return await Task.FromResult(new ServiceResponse<List<Events>>()
                {
                    Success = true,
                    Data = cache,
                    Message = "Homepage found",
                });
            }

            var homepage = await _homeRepo.GetHomepage();
            if (homepage == null)
            {
                return await Task.FromResult(new ServiceResponse<List<Events>>()
                {
                    Success = false,
                    Data = null,
                    Message = "Homepage not found",
                });
            }
            await _redisCacheService.SetAsync("homepage", homepage, TimeSpan.FromMinutes(5));
            return await Task.FromResult(new ServiceResponse<List<Events>>()
            {
                Success = true,
                Data = homepage,
                Message = "Homepage found",
            });
        }
    }
}