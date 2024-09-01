using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc; // Add the missing using directive

namespace backend.Services
{
    public class HomepageService: IHomepageService
    {
        private readonly IHomepageRepository _homeRepo;
        public HomepageService(IHomepageRepository homeRepo)
        {
            _homeRepo = homeRepo;
        }


        public async Task<ServiceResponse<List<Models.Events>>> GetHomepage(){
            var homepage = await _homeRepo.GetHomepage();
            if (homepage == null)
            {
                return await Task.FromResult(new ServiceResponse<List<Models.Events>>()
                {
                    Success = false,
                    Data = null,
                    Message = "Homepage not found",
                });
            }
            return await Task.FromResult(new ServiceResponse<List<Models.Events>>()
            {
                Success = true,
                Data = homepage,
                Message = "Homepage found",
            });
        }
        
    }
}