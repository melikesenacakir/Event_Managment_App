using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface IHomepageRepository
    {
        Task<List<Models.Events>?> GetHomepage();
    }
    public interface IHomepageService
    {
        Task<ServiceResponse<List<Models.Events>>> GetHomepage();
    }
}